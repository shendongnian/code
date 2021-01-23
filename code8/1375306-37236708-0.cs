    public class Notifications
    {
        public Notifications(AppSettings settings) {
            this.settings = settings;
        }
        public void SendEmail(string subject, string body) {
            SmptClient.Send(subject, body, settings["email address"]);
        }
    }
