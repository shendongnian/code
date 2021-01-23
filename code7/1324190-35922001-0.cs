        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (sender is FrameworkElement)
            {
                var fe = sender as FrameworkElement;
                var targetIvm = fe.DataContext as ItemViewModel;
                object obj = null;
                if(e.DataView.Properties.TryGetValue("ItemViewModel", out obj))
                {
                    var sourceIvm = obj as ItemViewModel;
                    vm.MoveItem(sourceIvm, targetIvm);
                }
            }
        }
        private void Grid_DragStarting(Windows.UI.Xaml.UIElement sender, DragStartingEventArgs args)
        {
            if (sender is FrameworkElement)
            {
                var fe = sender as FrameworkElement;
                var item = new KeyValuePair<string, object>("ItemViewModel", fe.DataContext);
                args.Data.RequestedOperation = DataPackageOperation.Move;
                args.Data.Properties.Add("ItemViewModel", fe.DataContext);
            }
        }
