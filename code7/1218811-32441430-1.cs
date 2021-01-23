        private Point? _startPoint;
        private void dataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }
        private void dataGrid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            // No drag operation
            if (_startPoint == null)
                return;
            var dg = sender as DataGrid;
            if (dg == null) return; 
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = _startPoint.Value - mousePos;
            // test for the minimum displacement to begin the drag
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged DataGridRow
                var DataGridRow=
                    FindAnchestor<DataGridRow>((DependencyObject)e.OriginalSource);
                if (DataGridRow == null)
                    return;
                // Find the data behind the DataGridRow
                var dataTodrop = (DataModel)dg.ItemContainerGenerator.
                    ItemFromContainer(DataGridRow);
                if (dataTodrop == null) return;
                // Initialize the drag & drop operation
                var dataObj = new DataObject(dataTodrop);
                dataObj.SetData("DragSource", sender);
                DragDrop.DoDragDrop(dg, dataObj, DragDropEffects.Copy);
                _startPoint = null;
            }
        }
        private void dataGrid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _startPoint = null;
        }
        private void dataGrid_Drop(object sender, DragEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            var dgSrc = e.Data.GetData("DragSource") as DataGrid;
            var data = e.Data.GetData(typeof(DataModel));
            if (dgSrc == null || data == null) return;
            // Implement move data here, depends on your implementation
            MoveDataFromSrcToDest(dgSrc, dg, data);
            // OR
            MoveDataFromSrcToDest(dgSrc.DataContext, dg.DataContext, data);
        }
        private void dataGrid_PreviewDragOver(object sender, DragEventArgs e)
        {
             // TO test if drop is allowed, to avoid drop 
             // if false e.Effects = DragDropEffects.None;
        }
        // Helper to search up the VisualTree
        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
