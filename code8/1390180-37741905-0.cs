    public class MultiThreadObservableCollection<T> : ObservableCollectionEnh<T>
    {
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var eh = CollectionChanged;
            if (eh != null)
            {
                Dispatcher dispatcher = (from NotifyCollectionChangedEventHandler nh in eh.GetInvocationList()
                                         let dpo = nh.Target as DispatcherObject
                                         where dpo != null
                                         select dpo.Dispatcher).FirstOrDefault();
                if (dispatcher != null && dispatcher.CheckAccess() == false)
                {
                    dispatcher.Invoke(DispatcherPriority.DataBind, (Action)(() => this.OnCollectionChanged(e)));
                }
                else
                {
                    // IMPORTANT NOTE:
                    // We send a Reset eventargs (this is inefficient).
                    // If we send the event with the original eventargs, it could contain indexes that do not belong to the collection any more,
                    // causing an InvalidOperationException in the with message like:
                    // 'n2' index in collection change event is not valid for collection of size 'n2'.
                    NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                    foreach (NotifyCollectionChangedEventHandler nh in eh.GetInvocationList())
                    {
                        nh.Invoke(this, notifyCollectionChangedEventArgs);
                    }
                }
            }
        }
    }
