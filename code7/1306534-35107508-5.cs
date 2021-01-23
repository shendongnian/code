    public partial class form1 : Form
    {
        private string vanilla = "Vanilla";
        private string chocolate= "Chocolate";
        private List<string> _values= new List<string>();
        public form1()
        {
            InitializeComponent();
        }
   
        public void button1_Click(object sender, EventArgs e)
        {
           if (!_values.Contains(vanilla))
           {
              _values.Add(vanilla);
           }           
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
           if (!_values.Contains(chocolate))
           {
              _values.Add(chocolate);
           } 
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            form2 form2 = new form2(_values);
            form2.Show();
            this.Hide();
        }
    }
