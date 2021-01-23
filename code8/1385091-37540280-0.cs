    public void UpdateColumnsItemsWithLargestColumnWidth()
        {
            if (Columns != null)
            {
                var maxColumn =Columns.First(y=>y.Column.ActualWidth == Columns.Max(x => x.Column.ActualWidth));
                foreach (var column in Columns)
                {                    
                    column.Column.Width = maxColumn.Column.ActualWidth;
                }
            }
        }
