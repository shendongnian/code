    public void ViewModel1(){
       public ViewModel1(){
          using(var db = new CustomerEntities()){
              Customers = db.Customers.Where(
                  p=>p.isActive = true &&    
                  p.hasOrder=true && 
                  p.AR > 0);
          }
       }
       public Customer SelectedCustomer {get;set;}
       public IEnumerable<Customer> Customers {get;set;}
       public ViewModel2 VMCustomerBilling {get;set;}
       public ViewModel3 VMCustomerOrders {get;set;}
    
       public void Post(){
            VMCustomerBilling = new ViewModel2(SelectedCustomer);
            VmCustomerOrders = new ViewModel3(SelectedCustomer);
       }
    }
