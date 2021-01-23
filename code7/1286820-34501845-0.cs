    Products.Items.AddRange(basket.ProductList.Select(p => new ListViewItem(new string[]
    { 
        p.Description,
        p.Quantity.ToString(...),
        p.UnitPrice.ToString(...),
         ...  
    })).ToArray());
