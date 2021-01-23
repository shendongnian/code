    class Item
    {
        public string Code {get;set;}
        public string Name {get;set;}
    }
    
    public List<Item> getCustomerNames()
    {
         var Customers = (from c in _context.OCRDs
         where c.CardType == "c"
         select new Item {Code = c.CardCode, Name = c.Name}
         ).ToList();
    
         return Customers;
    }
