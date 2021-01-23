    public SettingsWindow()
		{
			InitializeComponent();
			CoreAuthKeyTestButton.Click += (s, e) => { CoreAuthKeyTestButtonClickAction(); };
		}
		private void CoreAuthKeyTestButtonClickAction()
		{
			Logging.Write("Save Core Auth Key Button Click Called");
		}
