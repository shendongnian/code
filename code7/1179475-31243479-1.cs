    private bool IsMatch(string value, string searchCriteria)
    {
       if(searchCriteria == null || value == null) return true;   
       return value.ToUpper().Contains(searchCriteria.ToUpper());
    }
    public Products FindProducts(string color, string size, string comment, string owner, string buyer, datetime? after, datetime? before)    
    {
        using(MyDbContext cont = new MyDbContext())
        {
            return cont.Products.Where((p) =>
            {
               return IsMatch(p. color, color) && IsMatch(p.size, size) && 
               IsMatch(p.comment, comment) && IsMatch(p.owner, owner) && 
               IsMatch(p.buter, buyer);  // add your logic for dates here
            });
        }   
    }
