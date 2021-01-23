    private void AddProd(object sender, RoutedEventArgs e)
    {
        if (ListBoxx.SelectedItem != null)
        {
            Fields fi = (Fields)this.ListBoxx.SelectedItem;
            fi.Quantity = txtQuantity.Text; // SET THE Quantity..
            ListBoxx2.Items.Add(fi);
        }
        else
        {
            MessageBox.Show("Selecione um item para adicionar!");
        }
    }
