    public class TextReader : Form
    {
        string[] lines;
        int currentIndex = 0;
        public TextReader ()
        {
            InitializeComponent();
            lines = File.ReadAllLines("C:\\myTextFile.txt"); 
        }
        public void Button_Click(object sender, EventArgs e)
        {
            TextBox1.Text = lines[currentIndex];
            currentIndex++;
        }
    }
