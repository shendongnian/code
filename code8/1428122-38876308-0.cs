    public Form1()
    {
        InitializeComponent();
        BindingList<Employee> list = new BindingList<Employee>();
        list.Add(new Employee() { Name = "Test1" });
        list.Add(new Employee() { Name = "Test2" });
        list.Add(new Employee() { Name = "Test3" });
        list.Add(new Employee() { Name = "Test4" });
        list.Add(new Employee() { Name = "Test5" });
    
        dataGridView1.DataSource = list;
    }
