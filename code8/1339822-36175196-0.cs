    static void Main(string[] args)
    {
        string itemNameTitle = "ITEM NAME";
        string qtyTitle = "QTY";
        string priceTitle = "PRICE";
        List<string> itemName = new List<string> { "Banana Large Yellow", "Brie Cheese 6 pack round", "Indian Mango Box"};
        List<string> qty = new List<string> { "1", "3", "10" };
        List<string> price = new List<string> { "2.00", "30.00", "246.00" };
        //Insert titles into first positions of Lists
        itemName.Insert(0, itemNameTitle);
        qty.Insert(0, qtyTitle);
        price.Insert(0, priceTitle);
        //Dynamically get number of spaces according to longest word length + 2
        int padValue1 = itemName.OrderByDescending(s => s.Length).First().Length + 2;
        int padValue2 = qty.OrderByDescending(s => s.Length).First().Length + 2;
        int padValue3 = price.OrderByDescending(s => s.Length).First().Length + 2;
        for (int i = 0; i < itemName.Count; i++)
        {
            Console.Write(itemName[i].PadRight(padValue1));
            Console.Write(qty[i].PadRight(padValue2));
            Console.Write(price[i]);
            Console.Write(Environment.NewLine);
        }
    }
