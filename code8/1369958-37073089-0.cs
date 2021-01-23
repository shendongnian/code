    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			var loginFormMax = new LoginFormMax { Owner = this };//save main form as owner inside child form
			loginFormMax.Show();
		}
	}
