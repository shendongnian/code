    using System.Windows.Forms;
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            Rand m = new Rand();
            public Form1()                  // constructor of Form1
            {
                InitializeComponent();
                textBox1.Text = m.myRand.ToString();
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
            }
        }
        public class Rand
        {
            public int myRand = new Random().Next(10);
            public Rand() { }
        }
    }​
