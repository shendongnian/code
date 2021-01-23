    public partial class Form1 : Form
    { 
        private Mediator _mediator = new Mediator(); 
        public Form1()
        {
            InitializeComponent();
        }
        private void Add_to_Array_Click(object sender, EventArgs e)
        {
            var newEmployee = new Employee
            {
                Name = txtName.Text,
                Department = txtDepartment.Text,
                ID = int.Parse(txtID.Text)
            };
            _mediator.Employees.Add(newEmployee);
            Exchange();
            //-----------------------------------
            txtDepartment.Text = "";
            txtID.Text = "";
            txtName.Text = "";
        }
        private void Search_Click(object sender, EventArgs e)
        {
            foreach (var employee in _mediator.Employees)
            {
                listBox1.Items.Add(employee.Name);
                listBox1.Items.Add(employee.Department);
                listBox1.Items.Add(employee.ID.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Employees = _mediator.Employees;
            f2.Show();
        }
    }
    public partial class Form2 : Form
    {
        public List<Employee> Employees { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Show2_Click(object sender, EventArgs e)
        {
            foreach (var employee in Employees)
            {
                listBox1.Items.Add(employee.Name);
                listBox1.Items.Add(employee.Department);
                listBox1.Items.Add(employee.ID.ToString());
            } 
        }
    }
    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public int ID { get; set; } 
    }
    class Mediator
    {
        public List<Employee> Employees { get; private set; }
        public Mediator()
        {
            Employees = new List<Employee>();
        }
    }   
