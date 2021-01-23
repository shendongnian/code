	namespace WirelessNetworkManager
	{
		public partial class NewNetworkForm : Form
		{
			public NewNetworkForm()
			{
				InitializeComponent();
			}
			private MainForm mainForm = null;
			public NewNetworkForm(Form callingForm)
			{
				mainForm = callingForm as MainForm;
				InitializeComponent();
			}
			private void OKButton_Click(object sender, EventArgs e)
			{
				// create wifi profile with user input
				Tools.RefreshWiFiProfiles(this.mainForm.ProfilesListView);
				this.Close();
			}
		}
	}
