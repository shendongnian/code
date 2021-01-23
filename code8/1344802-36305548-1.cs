    protected void Button1_Click(object sender, EventArgs e)
    {           
    	string finalText = @"<input type=""text"" ID=""T1"" runat=""server"">"; 
    	var textbox = new TextBox();
    	textbox.ID = "TB1";
    	this.TextBoxPlaceHolder.Controls.Add(new LiteralControl(finalText));
    	this.TextBoxPlaceHolder.Controls.Add(textbox);
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {          
    	TextBox txtAddress2 = (TextBox)Page.FindControl("TB1");  
    	foreach (Control c in TextBoxDiv.Controls)
    	{
    		if (c is TextBox)
    		{
    			TextBox txt = (TextBox)c;
    			string str = txt.Text;
    		}
    	}
    }
