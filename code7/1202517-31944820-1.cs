    public Dictionary<string, string> GetCustomerNames()
    { 
         var Customers = (from c in _context.OCRDs
                          where c.CardType == "c"
                          select c)
                          .ToDictionary(c => c.CardCode, c => c.CardName);
    
         return Customers;
    }
