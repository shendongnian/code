    public Customer GetCustomer(int? id, DateTime? dob, string fName, 
      string mi, string lName)
    {    
      IQuerable<Customer> query = CustomerDb.customers;
      if (id.HasValue)
      {
        query = query.Where(c => c.id == id.Value)
      }
      else
      {
        query = query.Where(c => c.id == null)      
      }
      if (dob.HasValue)  
      {
        query = query.Where(c => c.Dob == dob.Value)
      }
      else
      {
        query = query.Where(c => c.Dob == null)      
      }
      if (!string.IsNullOrWhitespace(fName))
      {
        query = query.Where(c => c.FName == fName)
      }
      else
      {
        query = query.Where(c => c.Fname == null)      
      }
      // repeate for mi, lName
      var result = query.FirstOrDefault();
      return result;
    }
