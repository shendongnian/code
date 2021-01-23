            private void UIElement_OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            e.Handled = true;
            ListViewItem item = sender as ListViewItem;
            if (item == null) return;
            if (e.Cumulative.Translation.X > 150)
            {
                item.IsSelected = !item.IsSelected;
                e.Complete();
            }
        }
