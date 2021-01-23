    public static readonly DependencyProperty DelayElapsedProperty =
            DependencyProperty.Register("DelayElapsed", typeof(double), typeof(DelayedActionCommandButton), new PropertyMetadata(0d));
    public static readonly DependencyProperty DelayMillisecondsProperty =
            DependencyProperty.Register("DelayMilliseconds", typeof(int), typeof(DelayedActionCommandButton), new PropertyMetadata(1000));
	public double DelayElapsed
        {
            get { return (double)this.GetValue(DelayElapsedProperty); }
            set { this.SetValue(DelayElapsedProperty, value); }
        }
       
        public int DelayMilliseconds
        {
            get { return (int)this.GetValue(DelayMillisecondsProperty); }
            set { this.SetValue(DelayMillisecondsProperty, value); }
        }
