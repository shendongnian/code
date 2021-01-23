		public partial class Form1 : Form
		{
				public Form1()
				{
					InitializeComponent();
				}
				private void Form1_Load(object sender, EventArgs e)
				{
					string[] args = System.Environment.GetCommandLineArgs().Skip(1).ToArray();
					textBox1.Text = String.Join(" ", args);
				}
				private void button2_Click(object sender, EventArgs e)
				{
					ProcessStartInfo start = new ProcessStartInfo();
					start.Arguments = "-add-text \"/ CALL OFF\" -font \"Helvetica-Bold\" -font-size 14 -pos-left \"194 776\" "
					                  + "\"" + textBox1.Text + "\"" + " -o out.pdf";
					start.FileName = "cpdf";
					Process.Start(start);
				}
		}
