     void ShowToast(string whattext)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            stringElements[0].AppendChild(toastXml.CreateTextNode(whattext));
            ToastNotification toast = new ToastNotification(toastXml);
            toast.Activated += ToastActivated;
            toast.Dismissed += ToastDismissed;
            toast.Failed += ToastFailed;
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        private void ToastFailed(ToastNotification sender, ToastFailedEventArgs args) { }
        private void ToastDismissed(ToastNotification sender, ToastDismissedEventArgs args) { }
        private void ToastActivated(ToastNotification sender, object args) { }
