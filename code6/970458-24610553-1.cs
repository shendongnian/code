    foreach (DataGridTextColumnEx column in dg.Columns)
            {
                if (hiddenColumns.Contains((string)column.Name))
                    column.Visibility = Visibility.Collapsed;
                else
                    column.Visibility = Visibility.Visible;
            }
