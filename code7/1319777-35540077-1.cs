    public class DelayedEventTrigger : System.Windows.Interactivity.EventTrigger
    {
        private EventArgs args;
        private DispatcherTimer dispatcherTimer;
    
        public static readonly DependencyProperty DelayProperty =
            DependencyProperty.Register("Delay", typeof(int), typeof(DelayedEventTrigger), new PropertyMetadata(1000));
    
        public int Delay
        {
            get { return (int)base.GetValue(DelayProperty); }
            set { base.SetValue(DelayProperty, value); }
        }
    
        protected override void OnEvent(EventArgs eventArgs)
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
            }
            args = eventArgs;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(Delay);
            dispatcherTimer.Tick += new EventHandler(OnDispatcherTimerTick);
            dispatcherTimer.Start();
        }
    
        protected override void OnDetaching()
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
            }
            base.OnDetaching();
        }
    
        private void OnDispatcherTimerTick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            InvokeActions(args);
        }
    }
