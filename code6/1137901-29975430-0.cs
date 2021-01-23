     foreach (var item in dgr.ItemsSource)
            {
                var row = dgr.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                bool IsChecked = (bool)((CheckBox)dgr.Columns[8].GetCellContent(row)).IsChecked;
                if (IsChecked)
                {
                    string itemCode = ((TextBlock)dgr.Columns[2].GetCellContent(row)).Text;
                    lstItemCodes.Add(itemCode);
                }
            }
