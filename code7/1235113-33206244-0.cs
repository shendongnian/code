        private void dataGridInvoice_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
                    
                    DataGridRow newRow = (DataGridRow)dataGridInvoice.ItemContainerGenerator.ContainerFromIndex(dataGridInvoice.Items.Count - 1);
                    DependencyObject reference = newRow;
                  //  MessageBox.Show(Convert.ToString(VisualTreeHelper.GetChildrenCount(reference)));
                    string invoiceNumber = null;
                    int _supplier = 0;
                    int _shop = 0;
                    DateTime _date = DateTime.Now;
        
        
                    if (newRow != null)
                    {
                        DataGridCellsPresenter presenter = GetVisualChildHelper<DataGridCellsPresenter>(newRow);
        
                        if (presenter == null)
                        {
                            dataGridInvoice.ScrollIntoView(newRow, dataGridInvoice.Columns[1]);
                            presenter = GetVisualChildHelper<DataGridCellsPresenter>(newRow);
                        }
        
                        DataGridCell cell0 = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(0);
                        DataGridCell cell1 = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(1);
                        DataGridCell cell2 = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(2);
                        DataGridCell cell3 = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(3);
        
                        invoiceNumber = InvoiceNumber.Text;
                        int value = Convert.ToInt32(shopComboBox.SelectedValue);
                        _shop = value;
        
                        value = Convert.ToInt32(supplierComboBox.SelectedValue);
                        _supplier = value;
        
                        _date = Convert.ToDateTime(datePicker.Text);
                        
                        cell0.Content = invoiceNumber;
                        cell1.Content = _shop;
                        cell2.Content = _date;
                        cell3.Content = _supplier;
                    }
        
                    e.NewItem = new Invoice() { suppInvNumber = invoiceNumber, shop = _shop, supplier = _supplier, date = _date };
        
         }
            public static T GetVisualChildHelper<T>(Visual parent) where T : Visual
            {
                T child = default(T);
                int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < numVisuals; i++)
                {
                    Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                    child = v as T;
                    if (child == null)
                    {
                        child = GetVisualChildHelper<T>(v);
                    }
                    if (child != null)
                    {
                        break;
                    }
                }
                return child;
            }
