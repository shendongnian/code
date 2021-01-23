    public class CControlAnimator: IAnimator
    {
        public Control control { get; set; }
        private Timer timer;
        // Data needed for animation
        public CControlAnimator()
        {
            timer = new Timer();
            timer.Tick += TimerTick;
        }
        public void Start()
        {
            timer.Enabled = true;
        }
        public void Stop()
        {
            timer.Enabled = false;
        }
        public void TimerTick(object sender, EventArgs e)
        {
            // Do the animation
        }
