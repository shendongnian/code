        private LoginUserControl login = new LoginUserControl();
        private CreateRecUserControl createRec = new CreateRecUserControl();
        public ApplicationContainer()
        {
            InitializeComponent();
            login.CreateButtonEvent += gotoCreate;
        }
