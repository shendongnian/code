    private void clbxAddonsT_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtOrderSubtotal2.Text = clbxAddonsT.CheckedItems.Cast<string>()
                                                         .Sum(i => this.GetPrice(i))
                                                         .ToString();
    }
    private double GetPrice(string item)
    {
        switch (item)
        {
            case "Lettuce":
                return 0.25;
            case "Tomatoes":
                return 0.20;
            default:
                return 0.0;
        }
    }
