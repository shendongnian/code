    class Item
    {
        public string CardCode {get;set;}
        public string CardName {get;set;}
    }
    
    public List<Item> getCustomerNames()
    {
         var Customers = (from c in _context.OCRDs
                          where c.CardType == "c"
                          select new Item { CardCode = c.CardCode, CardName = c.CardName }
                          ).ToList();
    
         return Customers;
    }
