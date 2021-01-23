        public LogOn_ViewModel()
        {
            this.CurrentUser = new User();
            this.LogOnCommandParameter = new CommandParameter() { Obj = this.CurrentUser, Command = Command.LogOn, Link_1 = "Main_ViewModel", Link_2 = "" };
            this.RecoveryCommandParameter = new CommandParameter() { Obj = this.CurrentUser, Command = Command.Recovery, Link_1 = "Recovery_ViewModel", Link_2 = "" };
            this.RegesterCommandParameter = new CommandParameter() { Obj = this.CurrentUser, Command = Command.Regester, Link_1 = "Regester_ViewModel", Link_2 = "" };
        }
        private User _CurrentUser;
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set { _CurrentUser = value; }
        }
        
        public CommandParameter LogOnCommandParameter { get; set; }
        public CommandParameter RecoveryCommandParameter { get; set; }
        public CommandParameter RegesterCommandParameter { get; set; }
    }
