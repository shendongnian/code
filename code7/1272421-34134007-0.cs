                var ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            var ToastXML = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var ToastText = ToastXML.GetElementsByTagName("text");
            (ToastText[0] as XmlElement).InnerText = message;
            var ToastNode = ToastXML.SelectSingleNode("/toast");
            var Toast = new ToastNotification(ToastXML);
            Toast.ExpirationTime = DateTimeOffset.Now.AddSeconds(2);
            ToastNotifier.Show(Toast);
