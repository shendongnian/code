    static class Program
    {
    	[STAThread]
    	static void Main()
    	{
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		var data = new MyObject { IBAN = "GB29NWBK60161331926819" };
    		var form = new Form();
    		var tbIBAN = new TextBox { Parent = form, Left = 8, Top = 8, Width = form.ClientSize.Width - 16, Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right };
    		tbIBAN.DataBindings.Add("Text", data, "IBAN", true);
    		Application.Run(form);
    	}
    }
