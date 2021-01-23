       public class ThreadedBindingList<T> : BindingList<T>
        {
    
            public SynchronizationContext SynchronizationContext
            {
                get { return _ctx; }
                set { _ctx = value; }
            }
    
            SynchronizationContext _ctx;
            protected override void OnAddingNew(AddingNewEventArgs e)
            { 
                if (_ctx == null)
                {
                    BaseAddingNew(e);
                }
                else
                {
                    SynchronizationContext.Current.Send(delegate
                    {
                        BaseAddingNew(e);
                    }, null);
                }
            }
            void BaseAddingNew(AddingNewEventArgs e)
            {
                base.OnAddingNew(e);
            }
            protected override void OnListChanged(ListChangedEventArgs e)
            {
                if (_ctx == null)
                {
                    BaseListChanged(e);
                }
                else
                {
                    _ctx.Send(delegate { BaseListChanged(e); }, null);
                }
            }
            void BaseListChanged(ListChangedEventArgs e)
            {
                base.OnListChanged(e);
            }
        }
