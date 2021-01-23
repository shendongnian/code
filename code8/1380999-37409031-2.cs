    public partial class MainFrm : Form
	{
		public MainFrm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void okbtn_Click(object sender, EventArgs e)
		{
			foreach (Control c in Controls)
			{
				if (c.GetType() == typeof (Panel))
				{
					enumerate_panel_child_contols((Panel)c);
				}
			}
			MessageBox.Show(@"done");
		}
		
		void enumerate_panel_child_contols(Panel pnl)
		{
			StringBuilder _sbtmp = new StringBuilder();
			foreach (Control c in pnl.Controls)
			{
				if (c.GetType() == typeof(Button))
				{
					_sbtmp.AppendLine("ButtonName=>" + c.Name);
				}
				else if (c.GetType() == typeof(Panel))
				{
					enumerate_panel_child_contols((Panel)c);
					_sbtmp.AppendLine("PanelName=>" + c.Name);
				}
			}
			
			using(var sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + pnl.Name  + ".txt"))
			{
				sw.WriteLine(_sbtmp);
				sw.Close();
			}
			
			_sbtmp.Clear();
		}
	}
