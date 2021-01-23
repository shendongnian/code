	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			using (System.IO.StreamWriter streamWriter = new StreamWriter("Report.txt", false)) 
			{
				streamWriter.WriteLine(string.Format("Start Time : {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
			}
		}
		private void Form_Closed(object sender, EventArgs e)
		{
			using (System.IO.StreamWriter streamWriter = new StreamWriter("Report.txt", true)) 
			{
				streamWriter.WriteLine(string.Format("End Time : {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
			}
		}
	}
