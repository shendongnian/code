   	public partial class Form1 : Form
	{
		private Form2 frm;
		public bool form2IsOpen { get; set; }
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (form2IsOpen == false)
			{
				frm = new Form2();
				frm.Show();
				form2IsOpen = true;
			}
			else
			{
				frm.Close();
				form2IsOpen = false;
			}
		}
	}
