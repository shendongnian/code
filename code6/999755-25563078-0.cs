    public partial class ApplicationDataService
    {
        partial void SaveChanges_Executing()
        {
            var changes = this.DataWorkspace.ApplicationData.Details.GetChanges();
            var inserted = changes.AddedEntities;
            foreach (var entity in inserted)
            {
                try
                {
                    var report = (Report)entity;
                    if (report.Level.LevelName == "Critical")
                    {
                        sendNotification(report);
                    }
                }
                catch (InvalidCastException) {} 
               // Do nothing - this is just a simple way to filter the entity types 
               // in the EntityChangeSet 
            }
        }
        void sendNotification(Report report) {  
            MailMessage mm = new MailMessage("myemail", "targetEmail");
            mm.Subject = "Critical Report submitted!";
            mm.Body = report.ToString();
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "myUserName";
            NetworkCred.Password = "Password";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 25;
            smtp.Send(mm);
        }
    }
