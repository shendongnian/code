    persistence datos;
    protected override void OnCreate(Bundle bundle)
    {
        _wifiReceiver = new wifiReceiver();
        _manager = (WifiManager)GetSystemService(Context.WifiService);
        datos = new persistence (this);
        _wifiSignals = datos.recover();
        if(_wifiSignals.Count>0)
             StartScan();  
    }
