    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Form2 frm = new Form2();
			DialogResult res = frm.ShowDialog();
			if (res != System.Windows.Forms.DialogResult.OK)
			{
				frm.Dispose();
				return;
			}
			this.txtMaKeHoach.Text = frm.ChosenEntry;
			frm.Dispose();
		}
	}
