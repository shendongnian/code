        public class PeriodicAction
        {
            private int _frequencyMs;
            private readonly Timer _timer;
            private bool _enabled;
            public Action ActionMethod { get; private set; }
            public int FrequencyMs
            {
                get { return _frequencyMs; }
                set
                {
                    _frequencyMs = value;
                    _timer.Change(0, _frequencyMs);
                }
            }
            public bool Enabled
            {
                get { return _enabled; }
                set
                {
                    _timer.Change(value ? 0 : Timeout.Infinite, _frequencyMs);
                    _enabled = value;
                }
            }
            public bool IsRunning { get; private set; }
            public PeriodicAction(Action actionMethod, int frequencyMs)
            {
                this.ActionMethod = actionMethod;
                this._frequencyMs = frequencyMs;
                this._timer = new Timer(timerCallbackMethod, null, 0, frequencyMs);
            }
            private void timerCallbackMethod(object sender)
            {
                if (IsRunning) return;
                IsRunning = true;
                ActionMethod();
                _timer.Change(0, _frequencyMs);
                IsRunning = false;
            }
        }
