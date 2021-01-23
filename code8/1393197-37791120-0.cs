	public enum Genders {
		Female,
		Male
	}
	public YourVMClass {
		public Genders SelectedGender {get; set;}
	    private DelegateCommand _cmdSelectGender;
	    public DelegateCommand CmdSelectGender {
	        get { return _cmdSelectGender ?? (_cmdSelectGender = new DelegateCommand(SelectGender)); }
	    }
	    private void SelectGender(Object parameter) {
			SelectedGender = (Genders)parameter;
	    }
	}
