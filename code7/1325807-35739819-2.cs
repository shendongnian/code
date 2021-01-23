     var columns = (from cols in _context.columns
                      select cols).ToList(); // note I am getting everything not just column names here...
        
        
       var data = from cust in _context.customer
               join details in _context.custDetails on cust.id equals details.custid
               join o in _context.orders on cust.id equals o.custid
               where cust.id == XXXX
               select new Customer
               {
                Id = cust.Id,
                Name = cust.Name,
                Address = details.Address,
                City = details.City,
                State = details.State,
                OrderDate = o.OrderDate,
                Amount = o.Amount
               //15 other properties similarly
              }.ToList();
    
    var fileterdData = from d in data
                       select new Customer
                      {
                         Id = DisplayColumn("ID",columns)? cust.Id:null,
                         Name =  DisplayColumn("Name",columns)? cust.Name:null,
                         Address =  DisplayColumn("Address",columns)? details.Address:null,
                          // do similarly for all other columns
                      }.AsQueryable(); // returns IQueryable<Customer>
    
    private bool DisplayColumnn(string columnName,List<Columns> cols)
    {
    return cols.Where(x=>x.ColumnName==columnName).First().Display();
    }
