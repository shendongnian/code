    protected override void OnInit(EventArgs e)
    {
			ddStatus_Bind();
			rblInternalNotes.Items.Insert(0,new ListItem("External","0"));
			rblInternalNotes.Items.Insert(1,new ListItem("Internal","1"));
        
    }
