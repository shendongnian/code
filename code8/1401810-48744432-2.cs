    // Get a toast XML template
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);
            // Fill in the text elements
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            stringElements[1].AppendChild(toastXml.CreateTextNode("Message" + newMessage));
            // Specify the absolute path to an image
            string codeWebFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
            String imagePath = "file:///" + Path.GetFullPath(codeWebFolderPath+ "Resources\\FixSus.png");
            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;
            // Create the toast and attach event listeners
            ToastNotification toast = new ToastNotification(toastXml);
            
            toast.Activated += ToastActivated;
            toast.Dismissed += ToastDismissed;
            toast.Failed += ToastFailed;
            // Show the toast. Be sure to specify the AppUserModelId on your application's shortcut!
            ToastNotificationManager.CreateToastNotifier(APP_ID).Show(toast);
