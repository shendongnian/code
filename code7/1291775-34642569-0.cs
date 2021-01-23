    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(BadBackgroundLaunch);
            ThreadPool.QueueUserWorkItem(GoodBackgroundLaunch);
        }
        private void GoodBackgroundLaunch(object state)
        {
            this.Invoke((Action) (() =>
            {
                var form2 = new SecondForm();
                form2.Text = "Good One";
                form2.Show();
            }));
        }
        private void BadBackgroundLaunch(object state)
        {
            var form2 = new SecondForm();
            form2.Text = "Bad one";
            form2.Show();
        }
    }
