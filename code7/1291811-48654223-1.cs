    using System.IO;
    using System.Net;
    using System.Net.Http;
    namespace WindowsFormsApplication8
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                //setLabel();
                Timer timer = new Timer();
                timer.Interval = (100); // 10 secs
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            private void timer_Tick(object sender, EventArgs e)
            {
                setLabel();
            }
            public void setLabel()
            {
                var url = "http://192.168.0.105/data.txt";
                var textFromFile = (new WebClient()).DownloadString(url);
                label1.Text = textFromFile + "Kg";
            }
           
        }
    }
