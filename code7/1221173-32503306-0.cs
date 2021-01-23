	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			WindowsFormsApplication1.Properties.Settings.Default.Label = label1.Text + "!";//change the value
			WindowsFormsApplication1.Properties.Settings.Default.Save(); //save the change
			WindowsFormsApplication1.Properties.Settings.Default.Reload(); //instruct the form to reload the settings from the file
			label1.Text = WindowsFormsApplication1.Properties.Settings.Default.Label; //update the label text to show the change
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Text = WindowsFormsApplication1.Properties.Settings.Default.Label; // set the initial value
		}
