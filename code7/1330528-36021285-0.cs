      public static Shell Instance { get; set; }
             
            public static HamburgerMenu HamburgerMenu { get { return Instance.MyHamburgerMenu; } }
    
            public Shell()
            {
                Instance = this;
                this.InitializeComponent();
            }    
      
