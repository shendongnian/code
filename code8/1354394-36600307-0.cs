    int price;
    if(Int16.TryParse(lbl_total_price.Text, out price))
    {
         // If your conversion was successful, then price will be stored here
    }
    else
    {
         // Uh oh. It wasn't in the proper format.
    }
