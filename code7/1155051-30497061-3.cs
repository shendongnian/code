    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            process p = new process(this);
            p.Foo();
        }
        public void SetProgressMax(int max)
        {
            uiProgressBar.Value = 0;
            uiProgressBar.Minimum = 0;
            uiProgressBar.Maximum = max;
        }
        public void IncrementProgress()
        {
            uiProgressBar.Increment(1);
        }
    }
