    public partial class Form1 : Form
    {        
        Data Data1 {get; set;}
        public Form1(Data data)
        {
            InitializeComponent();
            Data1 = data;
        }
    
        private void buttonOpenForm2 _Click(object sender, EventArgs e)
        {
            //Repeat pattern
            Form2 frm2 = new Form2(Data1);
            frm2.Show();
        }    
    }
