	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		
		private void textBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Form2 form2 = new Form2();
				if (form2.ShowDialog() == DialogResult.OK)
				{
					textBox1.Text = form2.SetValueForText;
				}
			}
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(textBox1.Text);
		}
	}
