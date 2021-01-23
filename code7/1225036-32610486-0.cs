    public class LastFormClosingApplicationContext : ApplicationContext
    {
    	public LastFormClosingApplicationContext(Form mainForm) : base(mainForm) { }
    	protected override void OnMainFormClosed(object sender, EventArgs e)
    	{
    		for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
    		{
    			var form = Application.OpenForms[i];
    			if (form != MainForm)
    			{
    				MainForm = form;
    				return;
    			}
    		}
    		base.OnMainFormClosed(sender, e);
    	}
    }
