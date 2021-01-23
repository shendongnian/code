    var alertConfig = new AlertConfig {
        Message = "it is not valid",
        OkText = "Okely",
        OnOk = () => { Debug.WriteLine("ok pressed"); }
    };
    Mvx.Resolve<IUserDialogs>().Alert(alertConfig);
