    private void btnCandy_Click(object sender, EventArgs e)
    {
        bool found = false;
        foreach (var item in lstProducts.Items)
        {
            if (item.ToString().StartsWith("Candy"))
            {
                // update item title
                found = true;
                break; // no need to continue
            }
        }
        if(!found)
        {
            lstProducts.Items.Add("Candy");
        }
    }
