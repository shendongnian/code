    public class ActionInvoker
    {
        private DateTime _LastRunTime;
        private Action _Action;
        private double _Interval;
        public ActionInvoker(Action action, double interval)
        {
            _Action = action;
            _Interval = interval;
            _LastRunTime = DateTime.Now;
        }
        
        public void InvokeAction()
        {
            var now = DateTime.Now;
            if ((now - _LastRunTime).TotalMilliseconds >= _Interval)
            {
                _LastRunTime = now;
                _Action.Invoke();
            }
        }
