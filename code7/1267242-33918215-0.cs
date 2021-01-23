        public Form1(Boolean flag)
        {
            try
            {
                if (flag)
                    InitializeComponent();
                else
                    Environment.Exit(0);
            }
            catch (Exception)
            {  
            }
            
        }
