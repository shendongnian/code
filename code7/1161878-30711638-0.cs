	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		
		public string SetValueForText = "";
		private void button1_Click(object sender, EventArgs e)
		{
			SetValueForText = textBox1.Text;
			this.DialogResult = DialogResult.OK;
		}
	}
