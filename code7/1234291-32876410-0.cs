    namespace Jobbuppgift1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path1 = "c:\\Jobbuppg";//this or line below
        string path1 = @"c:\Jobbuppg";//this or line above
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int fileCount = Directory.GetFiles(path1, "*.xml", SearchOption.AllDirectories).Length;
            textBox1.Text = fileCount.ToString();
        }
    }
}
