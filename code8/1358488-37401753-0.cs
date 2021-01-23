            taskInstance.Canceled += (s, e) => {
                var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var toastTextElements = toastXml.GetElementsByTagName("text");
                toastTextElements[0].InnerText = e.ToString();
                ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
            };
