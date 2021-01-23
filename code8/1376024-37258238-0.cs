    var alertConfig = new AlertConfig {
        Message = "it is not valid",
        OnOk = () => { Debug.WriteLine("ok pressed"); }
    };
    Mvx.Resolve<IUserDialogs>().Alert(alertConfig);
