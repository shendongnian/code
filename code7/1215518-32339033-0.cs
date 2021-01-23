    class DisposeClosedViewsBehavior : RegionBehavior
    {
        protected override void OnAttach()
        {
            Region.Views.CollectionChanged += Views_CollectionChanged;
        }
        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Remove) return;
            foreach (var removedView in e.OldItems)
            {
                IDisposable disposableView = removedView as IDisposable;
                IDisposable disposableViewModel;
                var iviewView = removedView as IView;
                if (iviewView != null)
                {
                    disposableViewModel = iviewView.DataContext as IDisposable;
                }
                else
                {
                    var frameworkElementView = removedView as FrameworkElement;
                    disposableViewModel = frameworkElementView?.DataContext as IDisposable;
                }
                disposableView?.Dispose();
                disposableViewModel?.Dispose();
            }
        }
    }
