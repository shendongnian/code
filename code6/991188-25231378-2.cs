    public delegate void CalculateTotalFructiferousDelegate(string text);
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			textBox1.TextChanged += TextChanged;
			textBox2.TextChanged += TextChanged;
		}
		private void TextChanged(object sender, EventArgs e)
		{
			TextBox tb = (TextBox)sender;
			string text = tb.Text;
			//If it is a CPU intensive calculation
			Task.Factory.StartNew(() =>
			{
				//Do sometihing with text
				text = text.ToUpper();
				if (InvokeRequired)
					Invoke(new CalculateTotalFructiferousDelegate(calculateTotalFructiferous), text);
			});
		}
		public void calculateTotalFructiferous(string text)
		{
			totalFructiferous.Text = text;
		}
	}
