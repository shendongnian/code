    private static async void SendNotificationAsync()
    {
            //Setting\Access policies\DefaultFullSharedAccessSignature policy
            string connStr = "Endpoint=sb://[namespace].servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=xyz";
            var util = new ConnectionStringUtility(connStr);
            //toast in XML
            var toast = "<toast>    <visual>
                           <binding template="ToastText01">
                             < text id = "1" > Test message </ text >
                         </ binding >    </ visual > </ toast >";
            //call WNS
            var uri = "https://[namespace].servicebus.windows.net/[hub name]/messages/?api-version=2015-04";
            
            using (var httpClient = new HttpClient())
            {                
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                request.Content = new StringContent(toast);
                request.Headers.Add("Authorization", util.getSaSToken(uri, 1000));
                //request.Headers.Add("ServiceBusNotification-Tags", "TAG");
                request.Headers.Add("ServiceBusNotification-Format", "windows");
                request.Headers.Add("X-WNS-Type", "wns/toast");
                var response = await httpClient.SendAsync(request);
                await response.Content.ReadAsStringAsync();
            }
        }
