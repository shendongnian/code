	public partial class Form1 : Form
	{
		int principal, rate, years;
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			principal = Convert.ToInt32(loantextBox4.Text);
			rate = Convert.ToInt32(ratetextBox5.Text);
			years = Convert.ToInt32(yearworktextBox2.Text);
			outputlabel5.Text = (principal * ((rate * (1 + rate) ^ years) / ((rate + 1) ^ years) - 1)).ToString();
