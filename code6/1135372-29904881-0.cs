    public partial class Form1 : Form
    {
       private int[] array;
       private int mouseClickCount=0;
        public Form1()
        {
            InitializeComponent();
            GenerateRandomNumbers();
        }
    
    
        void GenerateRandomNumbers()
        {
            Random rnd = new Random();
            array = Enumerable.Range(1, 90).OrderBy(i => rnd.Next()).ToArray();
        }
    
    
       void button1_Click(object sender, EventArgs e)
        {
           if(mouseClickCount == 90)
           {
              mouseClickCount =0;
              richTextBox1.Clear();
           } 
            mouseClickCount++;
            richTextBox1.Text+=randomNumbers[mouseClickCount]+ " ";    
        }
    }
