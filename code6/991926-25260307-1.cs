    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected = DropDownList1.SelectedItem.ToString();
        if(selected == "Ward")
        {
            int NetAmount = 700 * 3; //you can use any int variable in place of "3" as well
            TextBox1.Text = NetAmount.ToString();
        }
        else if(selected == "Semi Ward")
        {
            TextBox1.Text = "1000";
        }
        else
        {
            TextBox1.Text = "2000"
        }
    }
