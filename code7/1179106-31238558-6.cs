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
				// passing "this" (MainForm) to the second form
				NewNetworkForm newNetworkForm = new NewNetworkForm(this);
				newNetworkForm.ShowDialog();
			}
		}
	}
