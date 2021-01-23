    delegate void AddContentDelegate(string Text);
    public partial class Form1 : Form
    {
        AddContentDelegate AddContent;
        public Form1()
        {
            InitializeComponent();
            AddContent = new AddContentDelegate(AddContentFunction);
        }
        void AddContentFunction(string Text)
        {
            MessageBox.Show(Text);
            textBox1.Text += Text;
        }
        void myProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            BeginInvoke(AddContent, e.Data);
        }
        // ...
    }
