    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            DataColumn prodName = new DataColumn("Products");
            dt.Columns.Add(prodName);
            dt.Rows.Add("a");
            dt.Rows.Add("b");
            dt.Rows.Add("c");
    
            comboBox1.DataSource = dt;
          
            comboBox1.DisplayMember = "Products";
            comboBox1.ValueMember = "Products";
        }
    }
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
