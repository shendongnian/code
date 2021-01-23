            //Create an instance of clsOrder using the overloaded constructor
            clsOrder cobjOrder = new clsOrder
                (int.Parse(txtQuantity.Text),                 //Error is Here
                 decimal.Parse(txtPrice.Text)),
                 txtDescription.Text);
    public clsOrder(int intQuantity, decimal decPrice, string decDescription)
    {
        this.Quantity = intQuantity;
        this.Price = decPrice;
        this.Description = decDescription;
    }
