    public partial class Form1 : Form
    {
        private int guess; //<-----declare in a visible scope 
        
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            guess = rnd.Next(1, 100); //<------this only happens once, make sure you change when and where needed.
        }
    
        public void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(Form1.guess));
        }
    }
