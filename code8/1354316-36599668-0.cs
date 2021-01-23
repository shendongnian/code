    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList medicineName = (DropDownList)sender;
        if (medicineName.SelectedValue != "-1") // if medicine name is selected
        {
            GridViewRow row = (GridViewRow)medicineName.Parent.Parent; // find row 
            int quantity = Convert.ToInt32(((DropDownList)row.FindControl("DropDownList4")).SelectedValue); // find Quantity 
            if (quantity != -1) // if quanity is selected
            {
                int price = 1; // TODO: here you take the prize from the database by medicine name
                price = price * quantity;
                TextBox txtPrice = (TextBox)row.FindControl("TextBox1"); // find price textbox for this row
                txtPrice.Text = Convert.ToString(price); // assign price value to this textbox
            }
        }
    }
