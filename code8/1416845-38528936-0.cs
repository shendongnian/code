    public class Form1: Form
    {
        private Timer _timer;
        public Form1()
        {
            InitializeComponent();
            _timer = new Timer(.....);
            _timer.Tick += Timer_Tick;
            // etc!!!
        }
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        string new_ip;
        try
        {
            new_ip = new System.Net.WebClient().DownloadString("https://api.ipify.org");
        }
        catch 
        { 
            return;
        }
        if (old_ip != new_ip)
        {
            pictureBox1.BackColor = Color.Red;
            File.AppendAllText(@"C:\users\pc\Desktop\ip.txt", new_ip + "\r\n");
            old_ip = new_ip;
            MessageBox.Show("New ip saved");
        }
        else
            pictureBox1.BackColor = Color.Green;
    }
