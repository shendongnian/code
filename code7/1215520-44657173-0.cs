    class DisposeClosedViewsBehavior : RegionBehavior
    {
        protected override void OnAttach() =>
            Region.Views.CollectionChanged += Views_CollectionChanged;
        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Remove)
                return;
            foreach (var removedView in e.OldItems)
            {
                using (removedView as IDisposable)
                {
                    try
                    {
                        dynamic d = removedView;
                        using (d.DataContext as IDisposable) { }
                    }
                    catch (RuntimeBinderException)
                    {
                        // no data context property
                    }
                }
            }
        }
    }
