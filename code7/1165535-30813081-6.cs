    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the starting index for the content we want to replace.
            int startingIndex = richTextBox1.Find("\"Hello\"");
             
            // Select the content to be replaced.
            richTextBox1.Select(startingIndex, "\"Hello\"".Length);
            
            // Replace the content.
            richTextBox1.SelectedText = "Hi";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "\"Hello\", my name is Bruce";
        }
    }
