    public void SendConfirmationAfterRegister(String EmailID, String UserName)
    {
        MailMessage mailMsg = new MailMessage();
        String BodyMsg = UserName + ", \r\n\nWe have received your request to become a user of our site.  Upon review, we will send you verification for site access.\r\n\n" +
            "Thank you, \r\n\nMuda Admin";
        try
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["AdminEmail"].ToString(), ConfigurationManager.AppSettings["Pwd"].ToString());
                client.EnableSsl = true;
                mailMsg.IsBodyHtml = true;
                client.Send(ConfigurationManager.AppSettings["AdminEmail"].ToString(), EmailID, "Received Your Request", BodyMsg);
                client.Send(ConfigurationManager.AppSettings["AdminEmail"].ToString(), "mymailId", "User Needs Access", EmailID + " looking for access the xyz Network Site.");
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
