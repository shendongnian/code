    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(
        ToastTemplateType.ToastImageAndText02);
    XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
    stringElements.Item(0).AppendChild(toastXml.CreateTextNode("Hello world!"));
    IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
    XmlAttribute launchAttribute = toastXml.CreateAttribute("launch");
    launchAttribute.Value = "pass data here"; // TODO: pass data here
    toastNode.Attributes.SetNamedItem(launchAttribute);
    ToastNotification toast = new ToastNotification(toastXml);
    ToastNotificationManager.CreateToastNotifier().Show(toast);
