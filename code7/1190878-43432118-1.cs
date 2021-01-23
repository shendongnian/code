    static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            var frm = new Form1();
		    frm.Show();
			Application.Run();
		}
	}
