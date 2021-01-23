    InitializeComponent();
            this.Loaded += Clock_Loaded;
        }
        void Clock_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = gd.Resources["animation"] as Storyboard;
            var sec = sb.Children[0] as DoubleAnimation;
            var min = sb.Children[1] as DoubleAnimation;
            var hr = sb.Children[2] as DoubleAnimation;
            sec.From = DateTime.Now.Second * 6 - 90;
            min.From = (DateTime.Now.Minute + ((double)DateTime.Now.Second / 60.0)) * 6 - 90;
            hr.From = (DateTime.Now.Hour + ((double)DateTime.Now.Minute / 60.0)) * 30 - 90;
            sec.To = sec.From + 360;
            min.To = min.From + 360;
            hr.To = hr.From + 360;
            sb.Begin();
        }
