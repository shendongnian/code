    private IList<ICommand> _commands;
    public IList<ICommand> Commands {
        get {
            if (_commands == null) {
                _commands = BeneficiaryList.Select(x => new MvxCommand<Beneficiary>(item => {
					...
				}));
            }
            return _commands;
        }
    }
