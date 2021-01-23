    using Windows.UI.Notifications;
    ...
    private void button1_Click(object sender, EventArgs e) {
        var xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
        var text = xml.GetElementsByTagName("text");
        text[0].AppendChild(xml.CreateTextNode("Hello world"));
        var toast = new ToastNotification(xml);
        ToastNotificationManager.CreateToastNotifier("anythinggoeshere").Show(toast);
    }
