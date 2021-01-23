    var toastConfig = new ToastConfig("Toasting...");
    toastConfig.SetDuration(3000);
    toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(12, 131, 193));
    
    UserDialogs.Instance.Toast(toastConfig);
