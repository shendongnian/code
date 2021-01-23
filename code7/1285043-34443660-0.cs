	public Form1()
	{
		InitializeComponent();
		panel1.BringToFront();
	}
	private void Up_Click(object sender, EventArgs e)
	{
		panel1.Dock = DockStyle.Fill;
		panel2.Dock = DockStyle.Top;
	}
	private void Down_Click(object sender, EventArgs e)
	{
		panel1.Dock = DockStyle.Fill;
		panel2.Dock = DockStyle.Bottom;
	}
