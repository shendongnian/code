    public class EqualsWaitHandle
    {
        private readonly object _locker = new object();
        private readonly int _lockValue;
        public int Value { get; private set; }
        public EqualsWaitHandle(int lockValue = 0, int initialCount = 0)
        {
            Value = initialCount;
            _lockValue = lockValue;
        }
        public void Signal() { AddCount(-1); }
        public void AddCount(int amount)
        {
            lock (_locker)
            {
                Value += amount;
                if (Value != _lockValue)
                    Monitor.PulseAll(_locker);
            }
        }
        public void Wait()
        {
            lock (_locker)
                while (Value  == _lockValue)
                    Monitor.Wait(_locker);
        }
    }
