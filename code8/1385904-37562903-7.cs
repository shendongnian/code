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
        public virtual void Start()
        {
            timer.Enabled = true;
        }
        public virtual void Stop()
        {
            timer.Enabled = false;
        }
        public void TimerTick(object sender, EventArgs e)
        {
            // Do the animation
            if (control != null)
            {
                control.Location = new System.Drawing.Point(control.Location.X + 2, control.Location.Y);
            }
        }
