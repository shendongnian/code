	public partial class Form1 : Form
	{
		private readonly AsyncAutoResetEvent wh = new AsyncAutoResetEvent(false);
		public async void button1_Click(object sender, EventArgs e)
		{
			//Some work
			MessageBox.Show("Before pause");
			string someVar = await activate();
			MessageBox.Show("After pause");
			//some other work which should only run when 'string someVar = activate();' above succeeds
		}
		private async Task<string> activate()
		{
			await wh.WaitAsync();
			return textBox1.Text;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			wh.Set();
		}
	}
