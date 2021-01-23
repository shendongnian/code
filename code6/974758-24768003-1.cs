        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
        private void UIElement_OnPreviewMouseDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Down) return;
            e.Handled = true;
            var indx = myDataGrid.SelectedIndex + 1;
            myDataGrid.SelectedIndex = indx;
            myDataGrid.CurrentCell = new DataGridCellInfo(myDataGrid.Items[indx], myDataGrid.Columns[0]);
            var row = this.myDataGrid.ItemContainerGenerator.ContainerFromItem(myDataGrid.CurrentCell.Item) as DataGridRow;
            var presenter = GetVisualChild<DataGridCellsPresenter>(row);
            var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromItem(myDataGrid.CurrentCell.Item);
            if (cell != null)
            {
                var contentPresenter = cell.Content as ContentPresenter;
                if (contentPresenter != null)
                {
                    var m = contentPresenter.ContentTemplate.FindName("sampleTextBox", contentPresenter);
                    ((TextBox) m).Focus();
                }
            }
        }
    }
