        using System;
        using System.Threading;
        public class UnityInvoker : MonoBehaviour
        {
            public UnityInvoker Instance { get; private set; }
            
            void Awake()
            {
                Instance = this;
                _updateThread = Thread.CurrentThread;
            }
            Action _stored;
            object _lock = new object();
            volatile Thread _updateThread;
            public void Invoke(Action action)
            {
                if (_updateThread == Thread.CurrentThread)
                {
                    lock (_lock) _stored += action;
                    Update();
                    return;
                }
                using (var waiter = new ManualResetEvent(false))
                {
                    action += () => waiter.Set();
                    lock (_lock)
                        _stored += action;
                    waiter.WaitOne();
                }
            }
            void Update()
            {
                _updateThread = Thread.CurrentThread;
                Action toDo;
                lock (_lock)
                {
                    toDo = _stored;
                    _stored = null;
                }
                if (toDo != null)
                    toDo();
            }
        }
