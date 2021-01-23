    ActiveXHost host;
    protected override void OnStart(string[] args) {
        var ctl = SomeAxHostWrapper();
        host = new ActiveXHost(ctl);
        ctl.HasMessage += MessageReceived;
    }
    protected override void OnStop() {
        host.Dispose();
        host = null;
    }
