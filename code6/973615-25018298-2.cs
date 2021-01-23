    protected void RadComboBox1_ItemDataBound(object o, RadComboBoxItemEventArgs e)
    { 
        DataRowView dataSourceRow = (DataRowView) e.Item.DataItem;  
        if(e.Item.Text == stringPO_NUM)
        {
            e.Item.Selected = true;
            e.Item.Value = stringPO_NUM;
        }
    }
