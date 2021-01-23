    static class  Program
    {
        static void Main(string[] args)
        {
            ArrayList mainList = new ArrayList();
            string enterMore="yes";
            while (enterMore == "yes" || enterMore == "YES")
            {
                ItemObject item = new ItemObject();
                Console.Write("Item code: ");
                item.itemCode = Console.ReadLine();
                Console.Write("Item description: ");
                item.description = Console.ReadLine();
                Console.Write("Price: RM");
                item.price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                item.quantity = int.Parse(Console.ReadLine());
                mainList.Add(item);
                                                       
                Console.Write("{Type 'yes' to enter more} Want to enter more?");
                enterMore = Console.ReadLine();
            }
            
            string searchMore = "yes";
            while (searchMore == "yes" || searchMore == "YES")
            {
               
                Console.Write("Enter item code to SEARCH?  ");
                string itemCode = Console.ReadLine();
                //Arraylist stores evarything as an object type. so we are casting object into itemObject
                ArrayList searchResults = new ArrayList(mainList.Cast<ItemObject>()
                                                 .Where(d => d.itemCode == itemCode)
                                                 .ToList());
                Console.Write("Search Results: ");
                foreach(Object item in searchResults){
                    ItemObject obj = (ItemObject)item;
                    Console.WriteLine(obj.itemCode);
                    Console.WriteLine(obj.description);
                    Console.WriteLine();
                }
               
                Console.Write("{Type 'yes' to search more} Want to search more?");
                searchMore = Console.ReadLine();
            }
            
        }
       
    }
    class ItemObject
    {
        public string itemCode { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public float quantity { get; set; }
    }
