        public MainPage()
        {
            DataContext = this;
            this.InitializeComponent();
            SetMenu(0);
        }
        private void SetMenu(int key)
        {
            switch (key)
            {
                case 0:
                    activeMenu.Navigate(typeof(HomeMenu));
                    break;
                //You can add in as many cases as you need
            }
        }
