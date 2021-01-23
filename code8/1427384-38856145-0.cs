    public interface IEmailSender
        {
            
            Task<bool> SendEmail(Email email, FormSettings settings);
    
        }
    
        public class EmailSender : IEmailSender
        {
    
            FormSettings ConfigSettings { get; set; }
    
            public async Task<bool> SendEmail(Email email, FormSettings settings)
            {
    
                var http = new HttpClient();
                http.DefaultRequestHeaders.Add("subscription-key", settings.tokenApiKey);
    
                try
                {
                    await http.PostAsync(settings.tokenApiUrl + "email", new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json"));
                }
                catch (Exception e)
                {
                    return false;
                }
    
                return true;
            }
        }
