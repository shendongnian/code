     public List<string> comments_tags = new List<string>();
    
            public string TBProperty
            {
                get;
                set;
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                this.DataContext = this;
    
                for (int i = 0; i < 20; i++)
                {
                    comments_tags.Add("Tag no: " + i);
                }
              
                foreach (string comment in comments_tags)
                {
                    TBProperty += comment + " ";
                }
    
            }
