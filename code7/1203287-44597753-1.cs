        public RelayCommand<EnumType> DoSomethingCommand { get; }
        public SomeViewModel()
        {
            DoSomethingCommand = new RelayCommand<EnumType>(DoSomethingCommandAction);
        }
        private void DoSomethingCommandAction(EnumType _enumNameConstant)
        {
         // Logic
         .........................
        }
