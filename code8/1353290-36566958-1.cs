    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = new BindingList<Person>
            {
                new Person { Name = "John", Age = 25 },
                new Person { Name = "Alice", Age = 32 },
                new Person { Name = "Peter", Age = 30 },
            };
        }
    }
