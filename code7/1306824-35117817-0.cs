    BindingList<Employee> employees = new BindingList<Employee>();
    private void Form1_Load(object sender, EventArgs e)
    	{
    		for (int i = 0; i < 10; i++)
    		{
    			var emp = new Employee { FirstName = "fn" + i, LastName = "ln" + i, EmployeeId = i };
    			employees.Add(emp);
    		}
    		dataGridView1.DataSource = employees;
    	}
    }class Employee
    {
    	public int EmployeeId { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    }
