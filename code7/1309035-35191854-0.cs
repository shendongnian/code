    public partial class HelloWorldView : Form
    {
        private readonly HelloWorldController MyHelloWorldController =
            new HelloWorldController("Hello world!!", TimeSpan.FromSeconds(1.0));
        public HelloWorldView()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MyHelloWorldController.Messages
                .ObserveOn(this)
                .Subscribe(message =>
                {
                    textBox1.Text += message + Environment.NewLine;
                });
            MyHelloWorldController.IsAutomateds
                .ObserveOn(this)
                .Subscribe(isAutomated =>
                {
                    button2.Text = "hello world - is " + (isAutomated ? "on" : "off");
                });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyHelloWorldController.Trigger();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MyHelloWorldController.IsAutomated = !MyHelloWorldController.IsAutomated;
        }
    }
