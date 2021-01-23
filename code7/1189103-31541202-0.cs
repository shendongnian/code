    ItemListWindow il = new ItemListWindow();
    il.Show();
    var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
    il.Top = desktopWorkingArea.Bottom + 100;
    il.printItemList(printerComboBox.SelectedItem.ToString());
    il.Close();
                            
