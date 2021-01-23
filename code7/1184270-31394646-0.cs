    using System.Windows.Forms;
    namespace StreamTextExample
    {
        using System.ComponentModel;
        using System.Threading;
        internal sealed partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, System.EventArgs e)
            {
                var timer = new BackgroundWorker();
                timer.DoWork += DoWork;
                timer.RunWorkerAsync();
            }
            private void DoWork(object sender, DoWorkEventArgs doWorkEventArgs)
            {
                for (var i = 0; i < 10; ++i)
                {
                    var del = new AddText(AddTextCallback);
                    Invoke(del, string.Format("{0} seconds have passed.\r\n", i));
                    Thread.Sleep(1000);
                }
            }
            private void AddTextCallback(string value)
            {
                textBox1.Text += value;
            }
            private delegate void AddText(string value);
        }
    }
