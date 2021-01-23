    int index=0;
    for (int i = 1; i < products.Count; i++)
    {
        if (products[i].Price > products[index].Price)
        {
            products[index].Enabled=false; //in case a partial max had true value before starting to iterate 
            index=i;   
        }
        else
        {
           products[i].Enabled=false;
        }
    }
    products[index].Enabled = true;
