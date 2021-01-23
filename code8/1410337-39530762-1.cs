    public override int Timeout {
        get {
            return _Timeout;
        }
        set {
            if (value<0 && value!=System.Threading.Timeout.Infinite) {
                throw new ArgumentOutOfRangeException("value", SR.GetString(SR.net_io_timeout_use_ge_zero));
            }
            if (_Timeout != value)
            {
                _Timeout = value;
                _TimerQueue = null;
            }
        }
    }
