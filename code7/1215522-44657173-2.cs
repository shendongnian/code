    class DisposeClosedViewsBehavior : RegionBehavior
    {
        protected override void OnAttach() =>
            Region.Views.CollectionChanged += Views_CollectionChanged;
        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!(e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace))
                return;
            foreach (var removedView in e.OldItems)
                MvvmHelpers.ViewAndViewModelAction<IDisposable>(removedView, d => d.Dispose());
        }
    }
