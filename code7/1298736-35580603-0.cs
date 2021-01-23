    var toastNoti = ToastContentFactory.CreateToastText02();
    toastNoti.TextHeading.Text = "TEXT IN BOLD";
    toastNoti.TextBodyWrap.Text = "TEXT IN NORMAL CASE ";
    toastNoti.Launch = "NOTIFICATION ARGUMENTS";    
    var doc = new XmlDocument();
    doc.LoadXml(toastNoti.ToString());
    var endNotification = new ToastNotification(doc);
    endNotification.Tag = "1";
    ToastNotificationManager.CreateToastNotifier().Show(endNotification);
