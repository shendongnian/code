    public class RegisterController : ApiController
    {
        private NotificationHubClient hub;
        public RegisterController()
        {
            hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://buildhub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=DuWV4SQ08poV6HZly8O/KQNWv3YRTZlExJxu3pNCjGU=", "build2014_2");
        }
        
        public class DeviceRegistration
        {
            public string Platform { get; set; }
            public string Handle { get; set; }
            public string[] Tags { get; set; }
        }
        // POST api/register
        // This creates a registration id
        public async Task<string> Post()
        {
            return await hub.CreateRegistrationIdAsync();
        }
        // PUT api/register/5
        // This creates or updates a registration (with provided PNS handle) at the specified id
        public async void Put(string id, DeviceRegistration deviceUpdate)
        {
            // IMPORTANT: add logic to make sure that caller is allowed to register for the provided tags
            
            RegistrationDescription registration = null;
            switch (deviceUpdate.Platform)
            {
                case "mpns":
                    registration = new MpnsRegistrationDescription(deviceUpdate.Handle);
                    break;
                case "wns":
                    registration = new WindowsRegistrationDescription(deviceUpdate.Handle);
                    break;
                case "apns":
                    registration = new AppleRegistrationDescription(deviceUpdate.Handle);
                    break;
                case "gcm":
                    registration = new GcmRegistrationDescription(deviceUpdate.Handle);
                    break;
                default:
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            registration.RegistrationId = id;
            registration.Tags = new HashSet<string>(deviceUpdate.Tags);
            try
            {
                await hub.CreateOrUpdateRegistrationAsync(registration);
            } catch (MessagingException e) {
                ReturnGoneIfHubResponseIsGone(e);
            }
        }
        // DELETE api/register/5
        public async void Delete(string id)
        {
            await hub.DeleteRegistrationAsync(id);
        }
        private static void ReturnGoneIfHubResponseIsGone(MessagingException e)
        {
            var webex = e.InnerException as WebException;
            if (webex.Status == WebExceptionStatus.ProtocolError)
            {
                var response = (HttpWebResponse)webex.Response;
                if (response.StatusCode == HttpStatusCode.Gone)
                    throw new HttpRequestException(HttpStatusCode.Gone.ToString());
            }
        }
    }
