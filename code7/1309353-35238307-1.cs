    public YourConstructor() // replace YourConstructor with your class name.
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            
            foreach (var c in ContentRoot.Children)
            {
                if (c.GetType() == typeof(TextBlock))
                {
                    var c1 = c as TextBlock;
                    c1.Foreground = new SolidColorBrush(Colors.Red);                  
                }
            }
        }
