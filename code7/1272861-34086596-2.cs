    private void productComboBox_SelectedValueChanged(object sender, EventArgs e)
	{
	    //productIdLabel.Text = productComboBox.SelectedValue.ToString();
        DataRowView selectedRow = comboBox1.SelectedValue as DataRowView;
        if (selectedRow != null)
        {
            productIdLabel.Text    = selectedRow["productID"].ToString();
            productPriceLabel.Text = selectedRow["productPrice"].ToString();
            ...
        }
    }
