    public partial class Form2 : Form
    {
        private IDisposable _SignalR;
     
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this._SignalR = new HubConnection("http://localhost:8080").CreateHubProxy("TestHub");
            this._SignalR.On<string>("SendAll", message => { textbox1.Text = message;}
        }
    }
