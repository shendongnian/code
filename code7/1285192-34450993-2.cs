     private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = txtTitle.Text;
                dr["Quantity"] = txtQuantity.Text;
                dr["Price"] = txtPrice.Text;
                dr["Brand"] = txtBrand.Text;
                dr["Total"] = Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(txtPrice.Text);
    
                dt.Rows.Add(dr);
            }
