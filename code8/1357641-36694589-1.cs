    foreach(RepeaterItem item in repRMAproduct.Items)
    {
        TextBox tbNewQty = (TextBox) item.FindControl("tbNewQty");
        string newQuantity = tbNewQty.Text.Trim();
        int quantity;
        if(int.TryParse(newQuantity, out quantity))
        {
            SaveNewRmaQuantity(product, quantity);
        };
    }
