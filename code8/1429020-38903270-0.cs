            private static MainWindow _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();
                return _instance;
            }
        }
