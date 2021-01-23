    class Item
    {
        public bool   IsCondition {get; set;}
        public string Name        {get; set;}
    }
    
    var itemsToCheck = new List<Item>()
    {
        new Item { IsCondition = true;  Name = "A",
        new Item { IsCondition = true;  Name = "B",
        new Item { IsCondition = false; Name = "C",
        new Item { IsCondition = true;  Name = "D",
    }
    foreach(var item in itemsToCheck)
    {
        if(!Item.IsCondition)
        {
            Console.WriteLine($"Item {item.Name} is false"); 
        }
    }
