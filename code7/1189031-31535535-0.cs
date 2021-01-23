	public partial class Form1 : Form
	{
		public event EventHandler ButtonClicked;
		private void RaiseButtonClicked()
		{
			if (ButtonClicked != null)
				ButtonClicked(this, EventArgs.Empty);
		}
		public Form1()
		{
			InitializeComponent();
		}
		private void Button1_Click(object sender, EventArgs e)
		{
			RaiseButtonClicked();
		}
	}
