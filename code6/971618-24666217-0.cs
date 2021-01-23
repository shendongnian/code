        public virtual event ProgressChangedEventHandler ProcessChanged
        {
            add
            {
                lock ( mEventLock ) { mBackgroundWorker.ProgressChanged += value; }
            }
            remove
            {
                lock ( mEventLock ) { mBackgroundWorker.ProgressChanged -= value;}
            }
        }
