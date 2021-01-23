    public partial class Form2 : Form
	{
		private string _ChosenEntry = "";
		public Form2()
		{
			InitializeComponent();
		}
		private void btnChoose_Click(object sender, EventArgs e)
		{
			//...
			_ChosenEntry = this.dataGridView1.SelectedCells[0].Value.ToString();
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
		public string ChosenEntry
		{
			get { return _ChosenEntry; }
		}
	}
