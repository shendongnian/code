        public Display()
        {
            var dm = Metrics;
            this.Height = dm.HeightPixels;
            this.Width = dm.WidthPixels;
            this.Xdpi = dm.Xdpi;
            this.Ydpi = dm.Ydpi;
            this.FontManager = new FontManager(this);
        }
        public static Android.Util.DisplayMetrics Metrics
        {
            get
            {
                return Application.Context.Resources.DisplayMetrics;
            }
        }
