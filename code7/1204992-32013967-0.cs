    public partial class Form1 : Form
    {
        private Timer _timer;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += _updateLabel();
           
        }
       
        private void _updateLabel()
        {
            label1.Text = (DateTime.Now - _start).ToString();
        }
        DateTime _start;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!_timer.Enabled)
            {
                _start = DateTime.Now;
                _timer.Start();
            }
            else _timer.Stop();
            _updateLabel();
        }
    }
