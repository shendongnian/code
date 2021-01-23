    public class Store
    {
      public string StoreID{get;set;}
      public IList<Department> Departments{get;set;}
    }
    public class Department
    {
      public string DepartmentID{get;set;}
      public Store Store{get;set;}
      public IList<Order> Orders{get;set;}
    }
    public class Order
    {
      public string OrderID{get;set;}
      public Department Department{get;set;}
    }
