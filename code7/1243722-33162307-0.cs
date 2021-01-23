    protected void Page_Load(object sender, EventArgs e)
    {
    	if (IsPostBack)
    	{
    		int tbCnt = Convert.ToInt32(hdnTbCnt.Value);
    
    		for (int i = 1; i <= tbCnt; i++)
    		{
    			var tb = new TextBox()
    			{
    				ID = string.Format("txt{0}", i)
    			};
    
    			panel1.Controls.Add(tb);
    		}
    	}
    }
    
    protected void AddTextBox_Click(object sender, EventArgs e)
    {
    	int tbCount = Convert.ToInt32(hdnTbCnt.Value);
    
    	var tb = new TextBox()
    	{
    		ID = string.Format("txt{0}", tbCount + 1)
    	};
    
    	panel1.Controls.Add(tb);
    
    	hdnTbCnt.Value = (tbCount + 1).ToString();
    }
