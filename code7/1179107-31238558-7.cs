	namespace WirelessNetworkManager
	{
		public partial class NewNetworkForm : Form
		{
			public NewNetworkForm()
			{
				InitializeComponent();
			}
			
			// a local variable to reference the first form (MainForm)
			private MainForm mainForm = null;
			
			// a second overloaded constructor accepting a form
			public NewNetworkForm(Form callingForm)
			{
				// mainForm now refers to the first form (MainForm)
				mainForm = callingForm as MainForm;
				InitializeComponent();
			}
			private void OKButton_Click(object sender, EventArgs e)
			{
				// create wifi profile with user input
				
				// accessing the ListView using this.mainForm
				Tools.RefreshWiFiProfiles(this.mainForm.ProfilesListView);
				this.Close();
			}
		}
	}
