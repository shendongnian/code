    public partial class form1 : Form
    {
        int faggleCount; //declare instance variable.
        public form1()
        {
            InitializeComponent();
        }
        public Button ButtonName { get { return } }
        public static int initFaggleCount;
        private void button1_Click(object sender, EventArgs e)
        {
            faggleCount = initFaggleCount++; //use instance variable
            string finalCalc = faggleCount.ToString();
            label1.Text = finalCalc;
            /*
            Console.WriteLine(faggleCount);
            Console.ReadLine();*/
        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*TextWriter tw = new StreamWriter("SavedFaggleCount.txt");
            tw.WriteLine();
            tw.Close();*/
            Console.WriteLine(faggleCount); //use instance variable
            Console.ReadLine();
        }
    }
