		public MultipleTextBoxControl(int identifier, IDataRegistrationService service)
		{
			InitializeComponent();
			newTextBoxGroup.Identifier = identifier;
			service.Register(newTextBoxGroup); // <---------
		}
