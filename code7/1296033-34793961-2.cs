            Pivot pivot = sender as Pivot;
            PivotItem pivotItemSelected = ((PivotItem) ((Pivot) sender).SelectedItem);
            for (int i = 0; i < pivot.Items.Count; i++)
            {
                PivotItem pivotItem = pivot.Items[i] as PivotItem;
                TextBlock tb = pivotItem.Header as TextBlock;
                if (pivotItem == pivotItemSelected)
                {
                    //Style 
                    tb.Foreground = new SolidColorBrush(Colors.Blue);
                }
                else
                {
                    tb.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
        }
    
