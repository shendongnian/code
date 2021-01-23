        public UserDoc()
        {
            InitializeComponent();
            Var_GetUserAction.DocSubmitted += OnDocSubmitted;
            //set properties to call event
            Var_GetUserAction.IsAllowed = true;
        }
