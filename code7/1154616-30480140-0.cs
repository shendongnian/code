    //UI Layer
    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		comboBox1.DisplayMember = "Name";
    		comboBox1.ValueMember = "CustomerID";
    		comboBox1.DataSource = new CustomerFacade().getCustomers();
    	}
    }
    
    //Facade Class
    public class CustomerFacade
    {
    
    	 public BindingList<ICustomer>  getCustomers()
    	{
    
    		BindingList<ICustomer> objects = new BindingList<ICustomer>();
    		for (int i = 0; i < 10; i++)
    		{
    			objects.Add(new Customer() { Name = "Customer " + i.ToString(), CustomerID = i });
    		}
    
    		return objects;
    	}
    }
    
    //Business Entity 
    public class Customer : ICustomer
    {
    	public Int32 CustomerID { get; set; }
    	public string Name { get; set; }
    }
    
    //Contracts
    public interface ICustomer
    {
    	Int32 CustomerID { get; set; }
    	string Name { get; set; }
    }
