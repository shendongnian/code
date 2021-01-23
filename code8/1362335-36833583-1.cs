    public YourForm ()
		{
			InitializeComponent();
			CustomInitializeComponent();
		}
		private void CustomInitializeComponent()
		{
			teamGroup.Text = LocalizedLanguage.GetValue("SelectedTeamLabel");
		}
