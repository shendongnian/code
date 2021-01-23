    namespace YourProgram
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			string path = "";
			//Declare the File Dialog
			OpenFileDialog ofd = new OpenFileDialog();
			private void button1_click(object sender, EventArgs e)
			{
				if (odf.ShowDialog() == DialogResult.OK)
				{
					path = ofd.FileName;
				}
			}
		}
	}
