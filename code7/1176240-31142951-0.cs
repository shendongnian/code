    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Show();
            new Thread(() =>
            {
                while (f.Opacity <= 100)
                {
                    Thread.Sleep(15);
                    //if (this.Opacity == cs.CheckMaxOpacityValue())
                    //{
                    //    thrdTimer.Abort();
                    //    break;
                    //}
                    f.Invoke((Action)delegate { f.Opacity += 0.06; });
                }
            }).Start();
        }
    }
