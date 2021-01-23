     public static event NotifierServiceEventHandler OnOk
        {
            add
            {
                lock (Locker)  // I'm not removing the locks.  May be the publisher works in a multithreaded business layer.
                {
                    _notifierServiceEventHandler += value;                  
                }
            }
            remove
            {
                lock (Locker)
                {
                    _notifierServiceEventHandler -= value;
                }
            }
        }
