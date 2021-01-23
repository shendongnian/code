    public void Update(Customer customer)  
    {  
    using (MyDataContext db = new MyDataContext())  
    {  
        var originalCustomer = db.Customers.Where(c => c.CustomerID == customer.CustomerID).FirstOrDefault();  
       // change the originalCustomer's properties with customer's properties. 
        db.SubmitChanges();  
    }  
    }
