    public class AddCustomerViewModel : Screen
    {
    	private readonly ICustomerService _customerService;
    
    	public AddCustomerViewModel(ICustomerService customerService)
    	{
    		_customerService = customerService;
    	}
    
    	//If button is named x:Name="SaveCustomer" CM will 
    	//bind it by convention to this method
    	public void SaveCustomer(Customer customer)
    	{
    		_customerService.Save(customer);
    	}
    }
    
    public class CustomerListViewModel : Screen
    {
    	private readonly ICustomerService _customerService;
    	private List<CustomerDisplayModel> _customers;
    
    	public CustomerListViewModel(ICustomerService customerService)
    	{
    		_customerService = customerService;
    	}
    
    	public List<CustomerDisplayModel> Customers
    	{
    		get { return _customers; }
    		set
    		{
    			_customers = value;
    			NotifyOfPropertyChange();
    		}
    	}
    
    	//only fires once, unlike OnActivate()
    	protected override void OnInitialize()
    	{
    		var customers = _customerService.LoadAllCustomers();
    
    		//could just use the model but this shows how one might map from
    		//the domain model to a display model, AutoMapper could be used for this
    		Customers = customers.Select(c => new CustomerDisplayModel(c)).ToList();
    	}
    }
    
    public interface ICustomerService
    {
    	List<Customer> LoadAllCustomers();
    	void Save(Customer customer);
    }
    
    //same as button, Label named x:Name="CustomerName" will bind
    // to CustomerName
    public class CustomerDisplayModel
    {
    	private readonly Customer _customer;
    
    	public CustomerDisplayModel(Customer customer)
    	{
    		_customer = customer;
    	}
    
    	public string CustomerName
    	{
    		get { return _customer.Name; }
    		set { _customer.Name = value; }
    	}
    
    	public string Surname
    	{
    		get { return _customer.Surname; }
    		set { _customer.Surname = value; }
    	}
    
    	public string Address
    	{
    		get { return _customer.Address; }
    		set { _customer.Address = value; }
    	}
    }
    
    public class Customer
    {
    	public int Id { get; set; }
    
    	public string Name { get; set; }
    
    	public string Surname { get; set; }
    
    	public string Address { get; set; }
    } 
 
