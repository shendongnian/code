    public void cbItems(ComboBox cmb, int parameter)
    {
         ComboBoxItem cbItem = new ComboBoxItem();
         cbItem.Content = parameter;
         cmb.Items.Add(cbItem);
    }
