	public partial class Form2 : Form
	{
		public bool IsCreate { get; set; }
		public Form2()
		{
			InitializeComponent();
		}
		private void Form2_Load(object sender, EventArgs e)
		{
			if (IsCreate)
			{
				//load specific controls/data for creating
			}
			else
			{
				//load specific controls/data for updating
			}
		}
	}
