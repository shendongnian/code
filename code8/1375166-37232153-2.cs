    protected void Button1_Click(object sender, EventArgs e)
    {
        // Get the selected item
        ListItem item = DropDownList1.SelectedItem;
        // Reset selected to false
        item.Selected = false;
        // Add to the cart dropdown
        DropDownList2.DataTextField = "productname";
        DropDownList2.DataValueField = "price";
        DropDownList2.Items.Add(item);
        DropDownList2.DataBind();
        int sum = DropDownList2.Items.Cast<ListItem>().Select(a => Convert.ToInt32(a.Value)).Sum();
        Label2.Text = Convert.ToString(sum);
    }
