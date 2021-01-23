    public class TimerWrapper
    {
        private Timer timer = new Timer();
        public event EventHandler WrapperTick;
        public bool Paused { get; set; }
        public TimerWrapper()
        {
            timer.Interval = 500;
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if(this.WrapperTick!=null && !this.Paused)
            {
                this.WrapperTick(this, e);
            }
        }
        public void Start()
        {
            this.timer.Start();
            this.Paused = false;
        }
        public void Stop()
        {
            timer.Stop();
            this.Paused = true;
        }
    }
    public partial class Form1 : Form
    {
        TimerWrapper tw = new TimerWrapper();
        public Form1()
        {
            InitializeComponent();
            
            tw.WrapperTick += tw_WrapperTick;
        }
        void tw_WrapperTick(object sender, EventArgs e)
        {
            this.Display.Text = (int.Parse(this.Display.Text) + 1).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.tw.Paused)
            {
                tw.Start();
            }
            else
            {
                tw.Stop();
            }
        }
    }
