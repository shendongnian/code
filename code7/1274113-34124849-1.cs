    public partial class Form1 : Form
    {
        private int Guess {get; set;} //<-----declare in a visible scope 
        
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            guess = rnd.Next(1, 100); //<------this only happens once, make sure you change when and where needed. 
                                      //Which would mean that that your Random object should also be moved outside the Form1() Constructor.
        }
    
        public void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Guess.ToString());
        }
    }
