    for (int i = 0; i < dt.Rows.Count; i++)
    {
        // Create and initialize a new tblProduct from the datatable row
        tblProduct current = new tblProduct();
        current.ProductName = dt.Rows[i]["Column2"].ToString();
        current.productPrice = Convert.ToDecimal(Math.Round(Convert.ToDecimal(dt.Rows[i]["Column1"].ToString())));
        // Add to your list of products
        products.Add(current);
        // This line is wrong because you overwrite the value at each loop
        label3.Text = dt.Rows[i]["Column3"].ToString();
        // Sum the price of the current tblProduct
        Total += (decimal)current.productPrice;
    }
    // Outside the loop update your total label
    textBox59.Text = "Rs: "+String.Format("{0:0.00}", Total);
