    public void PrintPrice()
    {
        if (this.GetPrice() > 10 && this.GetPrice() < 50)
            Console.WriteLine("Product: {0}", this.GetName());
        else
            Console.WriteLine("No products priced between 10 and 50 lei.");
    }
