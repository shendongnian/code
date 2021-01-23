    partial class Plugin{
        private bool _Enabled;
        public bool Enabled{
            get{
                return _Enabled;
            }
            set{
                _Enabled = value;
                if(value)
                    MyExecutionHandler += Run;
            }
        }
    }
