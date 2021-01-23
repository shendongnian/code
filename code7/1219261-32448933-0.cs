    void Main()
    {
    	var storeDepartments = new List<Department>();
    	
    	storeDepartments.Add(new Department { DepartmentId= 1, OrdersId= new List<int>(){1,2,3}});
    	storeDepartments.Add(new Department { DepartmentId= 2, OrdersId= new List<int>(){4,5}});
    	storeDepartments.Add(new Department { DepartmentId= 3, OrdersId= new List<int>(){6,7}});
    	
    	var stores = new List<Store>();
    	
    	var myStore = new Store {
    		StoreId= 1,
    		Departments= storeDepartments
    	};
    	
    	stores.Add(myStore);
    	
    	var store = stores.Find(s => s.Departments.First(d => d.DepartmentId == 2) != null);
    	
    	var orders = store.Departments.SelectMany(d => d.OrdersId).ToList();
    	
    	orders.Dump();
    }
    
    // Define other methods and classes here
    
    public class Store {
    	public int StoreId { get; set; }
    	public List<Department> Departments { get; set; }
    }
    
    public class Department {
    	public int DepartmentId { get; set; }
    	public List<int> OrdersId { get; set; }
    }
