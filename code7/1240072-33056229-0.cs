    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            Rand m = new Rand();            // m is generated only once
            public Form1()                  // constructor of Form1
            {
                InitializeComponent();
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                textBox1.Text = m.myRand.ToString();
            }
        }
    
        public class Rand
        {
            public int myRand = new Random().Next(10);
            public Rand() { }
        }
    }
