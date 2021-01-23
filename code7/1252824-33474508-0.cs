    public class MyDataGridView : DataGridView
    {
        ...
        #region Memory leak fix
        int _eventSubscriptionCount;
        /// <summary>
        /// Hack to fix event handler leak
        /// </summary>
        private void MemoryLeakFix()
        {
            Disposed += OnDisposed;
        }
        /// <summary>
        /// In some cases subscription keeps PinkDataGridView (and containing it controls) from removing by GC
        /// </summary>
        private void OnDisposed(object sender, EventArgs eventArgs)
        {
            for (int i = 0; i < _eventSubscriptionCount; i++)
            {
                base.OnHandleDestroyed(new EventArgs()); // unsubscribe SystemEvents.UserPreferenceChanged
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Interlocked.Increment(ref _eventSubscriptionCount);
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            Interlocked.Decrement(ref _eventSubscriptionCount);
        }
        #endregion Memory leak fix
    }
