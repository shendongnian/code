    public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
    {
        var applicationObject = (DTE2)application;
        var events = _applicationObject.Events;
        var buildEvents = (BuildEvents)events.BuildEvents;
        buildEvents.OnBuildBegin += new _dispBuildEvents_OnBuildBeginEventHandler(OnBuildBegin);
    }
