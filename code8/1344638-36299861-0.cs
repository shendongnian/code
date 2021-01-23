    private void Y_Incre_Button_Click(object sender, RoutedEventArgs e)
    {
        if (dataGrid.SelectedItems.Count != 0)
        {
            // Save DataGrid Row Selections
            List<int> selectedRowIndexList = new List<int>();
            foreach (object item in dataGrid.SelectedItems)
            {
                selectedRowIndexList.Add(dataGrid.Items.IndexOf(item));
            }
            for (int i = 0; i < bindingList.Count; i++)
            {
                int selectionIndex = dataGrid.SelectedIndex;
                if (selectionIndex > -1)
                {
                    ItemClass curItem = bindingList[selectionIndex];
                    int yNum = int.Parse(curItem.ycoord);
                    int yNum2 = yNum + 10;
                    string colonum = curItem.columnnumber;
                    string xpos = curItem.xcoord;
                    string ypos = yNum2.ToString();
                    string descrip = curItem.description;
                    bindingList[selectionIndex] = new ItemClass { columnnumber = colonum, xcoord = xpos, ycoord = ypos, description = descrip };
                }
            }
            // Restore DataGrid Row Selections
            dataGrid.SelectedItems.Clear();
            foreach (int rowIndex in selectedRowIndexList)
            {
                if (rowIndex < 0 || rowIndex > dataGrid.Items.Count - 1)
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));
                object item = dataGrid.Items[rowIndex];
                dataGrid.SelectedItems.Add(item);
            }
        }
        else
        {
            MessageBox.Show("No Rows Selected");
        }
    }
