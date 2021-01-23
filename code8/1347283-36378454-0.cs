	public partial class MyForm : Form
	{
		private TextBox _lastSelected = null;
		public MyForm()
		{
			InitializeComponent();
			textBox1.Enter += textBox_Enter;
			textBox2.Enter += textBox_Enter;
			textBox3.Enter += textBox_Enter;
		}
		private void buttonClearAll_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
		}
		private void buttonClearSelected_Click(object sender, EventArgs e)
		{
			if (_lastSelected == null) return;
			_lastSelected.Clear();
		}
		private void textBox_Enter(object sender, EventArgs e)
		{
			_lastSelected = (TextBox)sender;
		}
	}
