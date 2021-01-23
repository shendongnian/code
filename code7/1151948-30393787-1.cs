        private bool _commandIsExecuting;
        public virtual bool CommandIsExecuting
        {
            get
            { return _commandIsExecuting; }
            protected set
            {
                _commandIsExecuting = value;
                OnPropertyChanged(() => this.CommandIsExecuting);
            }
        }
    MyCommand = new AsyncRelayCommand<object>(CommandImplementation, CanIExecute, (b) => CommandIsExecuting = b);
