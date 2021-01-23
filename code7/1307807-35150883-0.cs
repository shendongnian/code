    protected void Page_Load(object sender, EventArgs e)
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.Button2);
                
                 //where button2 is the button by which pdf is generated and post back happens.          
            }
