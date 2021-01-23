    class MyVM : VMBase {
      private bool _isChangePending = false;
      public MyVM(IMyServerProxy proxy) {
        _proxy = proxy;
        _proxy.ValueChanged += OnValueChangedFromServer;
      }
      private void OnValueChangedFromServer(int value){
        _value = value;
        RaisePropertyChanged(() => Value);
      }
      public int Value { // bound to slider
        get { return _value; }
        set {
          _value = value;
          // only send send "stable" values to server
          if (!_isChangePending){
            _isChangePending = true;
            System.Threading.ThreadPool.QueueUserWorkItem(delegate {
              this.SendAfterStabilize(value);
              }, null);
          }
        }
      }
      private void SendAfterStabilize(int lastChangedValue) {
        while (true) {
          System.Threading.Thread.Sleep(1000);  // control coalescing delay here
          if (_value == lastChangedValue) {
            _isChangePending = false;
            _proxy.ModifyValue(lastChangedValue); // async
            return;
          }
          else {
            lastChangedValue = _value;
          }
        }
      }
