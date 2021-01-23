    namespace JsTools
    {
        public class JsTimer
        {
            private Timer _timer;
            private Action _actions;
            public void OnTick(Delegate d)
            {
                _actions += () => d.DynamicInvoke(JsValue.Undefined, new[] { JsValue.Undefined });
            }
            public void Start(int delay, int period)
            {
                if (_timer != null)
                    return;
               _timer = new Timer(s => _actions());
               _timer.Change(delay, period);
            }
            public void Stop()
            {
                _timer.Dispose();
                _timer = null;
            }
        }
    }
