    public static event EventHandler<OnThemeChangedEventArgs> IsThemeChanged;
    
    public class OnThemeChangedEventArgs : EventArgs
    {
        public AppTheme AppTheme { get; set; }
    
        public Accent Accent { get; set; }
    }
