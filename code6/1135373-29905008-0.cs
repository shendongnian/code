    namespace WindowsFormsApplication1
        {
          public class generate
            {
        public static int[] randomNumbers()
        {
            Random rnd = new Random();
            var randomNumbers = Enumerable.Range(1, 90).OrderBy(i => rnd.Next()).ToArray();
            return randomNumbers;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        string space = " ";
        int number;
        void button1_Click(object sender, EventArgs e)
        {
            int[] array = generate.randomNumbers();
            for (int i = 0; i < 90; i++)
            {
                richTextBox1.Text += randomNumbers[i].ToString() + space;
                richTextBox2.Text += array[i].ToString() + space;
                number = array[i];
            }
            textBox1.Text += number.ToString() + space;
            textBox2.Text += textBox1.Text;
            textBox1.Clear();
        }
    }
      }
