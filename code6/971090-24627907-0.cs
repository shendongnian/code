    namespace CSharpWPF
    {
        class ViewModel : DependencyObject
        {
            public ViewModel()
            {
                DispatcherTimer dt = new DispatcherTimer();
                dt.Interval = TimeSpan.FromSeconds(1);
                dt.Tick += (s, e) => ProgressService.Instance.CurrentProgress += 10;
                dt.Start();
            }
        }
        class ProgressService : DependencyObject
        {
            static ProgressService()
            {
                Instance = new ProgressService();
            }
            public static ProgressService Instance { get; private set; }
            public double CurrentProgress
            {
                get { return (double)GetValue(CurrentProgressProperty); }
                set { SetValue(CurrentProgressProperty, value); }
            }
            // Using a DependencyProperty as the backing store for CurrentProgress.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CurrentProgressProperty =
                DependencyProperty.Register("CurrentProgress", typeof(double), typeof(ProgressService), new PropertyMetadata(0.0));
        }
    }
