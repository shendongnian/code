	namespace WirelessNetworkManager
	{
		public partial class MainForm : Form
		{
			public MainForm()
			{
				InitializeComponent();
			}
			private void AddButton_Click(object sender, EventArgs e)
			{
				NewNetworkForm newNetworkForm = new NewNetworkForm(this);
				newNetworkForm.ShowDialog();
			}
		}
	}
