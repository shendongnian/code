    namespace MyShopEntities
    {
        public class MyCustomers
        {
            public int custId {get;set;}
    
            public string custName {get;set;}
            public string Address {get;set;}
            public string ShippingAddress {get;set;}
    
        }
    }
    public ActionResult Index()
    {
        ShopEntities.Customers cust = new MyShopEntities.MyCustomers();
        cust.CustName = "Sam";
        cust.IAddress = "xyz";
        cust.ShippingAddress = "xyz xyx xyz"; 
    
    }
    class BussinesModel
    {
       void Insert(ShopEntities.Customer customer)
       {
         // use ShopEntities.Customer only in wrapper
         // if you later switch to another Customer dependency,
         // you just change this     wrapper
    
         MyShopEntities.MyCustomers cust = new MyShopEntities.MyCustomers();
         cust.CustName = customer.CustName;
         cust.IAddress = customerIAddress;
         cust.ShippingAddress = customer.ShippingAddress; 
         InsertInternal(cust);
       }
    
       void InsertInternal(MyShopEntities.MyCustomer customer)
       {
           // use MyCustomer for all your bussines logic
       }
    }
