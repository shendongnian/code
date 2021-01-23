        public static double ScreenSizeInches(this IDisplay screen)
        {
            return Math.Sqrt(Math.Pow(screen.ScreenWidthInches(), 2) + Math.Pow(screen.ScreenHeightInches(), 2));
        }
        public static double ScreenWidthInches(this IDisplay screen)
        {
            return screen.Width / screen.Xdpi;
        }
        public static double ScreenHeightInches(this IDisplay screen)
        {
            return screen.Height / screen.Ydpi;
        }
