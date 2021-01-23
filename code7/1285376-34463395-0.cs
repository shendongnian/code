    if (Application.Current.Dispatcher.CheckAccess()){
    GUI code.
    }
    else{
    Application.Current.Dispatcher.Invoke(new System.Action(() => yourMethod));
    }
