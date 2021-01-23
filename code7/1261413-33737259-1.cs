    protected void ddl_proprietà_OnLoad(object sender, EventArgs e)
    {
        AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
        trigger.ControlID = ((Control)sender).UniqueID; // sender is the DropDown control
        UpdatePanel1.Triggers.Add(trigger);
    }
