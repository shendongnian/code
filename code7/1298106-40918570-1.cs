    public async Task SendEmailAsync(string email, string subject, string message, string url = "", string buttonText = "")
            {
                //Create a mail object
                var mailObject = new MailObject {
                    personalizations = new List<MailPersonalizations>(),
                    from = new Email { email = "no-reply@passion4it.be", name = "No-Reply Passion4IT" },
                    template_id = "cc84680c-a569-428b-ab26-9618584bc9ae"
                };
    
                //create the mail personalization
                var personalization = new MailPersonalizations();
                personalization.to = new List<Email>();
                personalization.to.Add(new Email { email = email});
                personalization.subject = subject;
                //Substitutions
                personalization.substitutions = new Dictionary<string, string>();
                personalization.substitutions.Add("-url-", url);
                personalization.substitutions.Add("-title-", subject);
                personalization.substitutions.Add("-custtext-", message);
                personalization.substitutions.Add("-buttonText-", buttonText);
    
                mailObject.personalizations.Add(personalization); //Adding to the mail object
    
                //SEND EMAIL USING SENDGRID API
                using(var client = new HttpClient())
                {
                    var jsonMail = JsonConvert.SerializeObject(mailObject);//convert object
    
                    client.DefaultRequestHeaders.Accept.Clear(); //Clear headers
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //Add Accept type
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "YOUR API KEY"); //Add Authorization
    
                    var response = await client.PostAsync("https://api.sendgrid.com/v3/mail/send", new StringContent(jsonMail, Encoding.UTF8, "application/json")); //Send the mail
                }
    
                return; //Closed
            }
