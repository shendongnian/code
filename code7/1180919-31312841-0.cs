    public sealed class PushNotification:IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            RawNotification notification = (RawNotification)taskInstance.TriggerDetails as RawNotification;
            if (notification != null)
            {
                ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
                XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
                var textElemets = toastXml.GetElementsByTagName("text");
                textElemets[0].AppendChild(toastXml.CreateTextNode(notification.Content));
                var imageElement = toastXml.GetElementsByTagName("image");
                imageElement[0].Attributes[1].NodeValue = "ms-appx:///Assets/50.png";
                ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
            }
        }
    }
