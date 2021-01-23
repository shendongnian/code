     // Get a toast XML template
     var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);
     // Fill in the text elements
     var stringElements = toastXml.GetElementsByTagName("text");
     stringElements[0].AppendChild(toastXml.CreateTextNode("Title"));
     stringElements[1].AppendChild(toastXml.CreateTextNode("Content"));
