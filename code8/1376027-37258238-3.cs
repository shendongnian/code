    var alertConfig = new AlertConfig {
        Message = "it is not valid",
        OkText = "Okely",
        OnAction = () => { Debug.WriteLine("ok pressed"); }
    };
    Mvx.Resolve<IUserDialogs>().Alert(alertConfig);
