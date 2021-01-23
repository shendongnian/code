    foreach (ListViewItem lvi in list_view_orderitems.Items)
    {
        if(lvi.SubItems[0].Text == list_Select_Product.SelectedItems[0].Text)
        {
            int UpdateQunat = Convert.ToInt32(lvi.SubItems[2].Text);
            int AddMe = Convert.ToInt32(txt_quantity.Text);
            UpdateQunat = UpdateQunat + AddMe;
            lvi.SubItems[2].Text = Convert.ToString(UpdateQunat);
            // adding it again. This line is not needed.
            list_view_orderitems.Items.Add(item);
         }
         else if (lvi.SubItems[0].Text != list_Select_Product.SelectedItems[0].Text)
         {
             list_view_orderitems.Items.Add(item);
         }
    }
