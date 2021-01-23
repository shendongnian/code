     public static MainForm instance=null;
        
        public static MainForm GetInstance()
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = new MainForm();
                return instance;
            }
        }
