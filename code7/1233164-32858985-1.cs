        public partial class Splash : Window
        {
            SynchronizationContext sc;
            System.Timers.Timer t;
            double i=0;
            double tempTop;
            double angle = 0;
            public Splash()
            {
                InitializeComponent();
                sc=SynchronizationContext.Current;
            }
            private void Move(object sender, MouseEventArgs e)
            {
                DragMove();
            }
    
            private void btnClose_Click(object sender, RoutedEventArgs e)
            {
                Application.Current.Shutdown();
            }
    
            private void btnMinim_Click(object sender, RoutedEventArgs e)
            {
                this.WindowState = WindowState.Minimized;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
               
                    l1.Content = "Helicopter Moving";
                if(t!=null)
                {
                    t.Stop();
                    t.Dispose();
                }
                    //for (double i = 0; i < 1; i += 0.05)
                    //{
                    //    this.Top -= i;
                    //    this.Left -= i;
                    //    Thread.Sleep(100);
                    //}
                    //l1.Content = "Helicopter Stopped";
                    tempTop = this.Top;
                    t = new System.Timers.Timer();
                    t.Interval = 10;
                    t.Enabled = true;
                    t.Elapsed += Change;
                    t.Start();
    
            }
            void Change(object sender, EventArgs e)
            {
                if (i <= 3)
                {
                    sc.Post(o =>
                    {
                        this.Top = tempTop * (Math.Cos(Math.PI * angle / 180));
                        this.Left -= i;
                        angle = (angle >= 360) ? 0 : ++angle;
                        i = i + 0.01;
                    }, null);
                }
                else
                {
                    t.Stop();
                    i = i * -1;
                }
                    
            }
        }
    }
