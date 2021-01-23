    public partial class form1 : Form
    {
        List<string> _values= new List<string>();
        public form1()
        {
            InitializeComponent();
        }
    
        public static string buttonValue = "";
        public static string buttonValue1 = "";
    
        public void button1_Click(object sender, EventArgs e)
        {
           if (!_values.Contains("Vanillaaaa"))
           {
              _values.Add("Vanillaaaa");
           }           
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
           if (!_values.Contains("Chocolate"))
           {
              _values.Add("Chocolate");
           } 
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            form2 form2 = new form2(_values);
            form2.Show();
            this.Hide();
        }
    }
