    public class EmailServiceIos : EmailService
    {
        public override bool CanSend
        {
            get
            {
                return MFMailComposeViewController.CanSendMail;
            }
        }
        public override void ShowDraft(
            string subject,
            string body,
            bool html,
            string[] to,
            string[] cc,
            string[] bcc,
            byte[] screenshot = null)
        {
            var mailer = new MFMailComposeViewController();
            mailer.SetMessageBody(body ?? string.Empty, html);
            mailer.SetSubject(subject ?? string.Empty);
            mailer.SetCcRecipients(cc);
            mailer.SetToRecipients(to);
            mailer.Finished += (s, e) => ((MFMailComposeViewController)s).DismissViewController(true, () => { });
            if (screenshot != null)
            {
                mailer.AddAttachmentData(NSData.FromArray(screenshot), "image/png", "screenshot.png");
            }
            UIViewController vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }
            vc.PresentViewController(mailer, true, null);
        }
        public override void ShowDraft(string subject, string body, bool html, string to, byte[] screenshot = null)
        {
            this.ShowDraft(subject, body, html, new[] { to }, new string[] { }, new string[] { }, screenshot);
        }
    }
