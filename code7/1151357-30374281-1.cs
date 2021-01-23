    void yourTasksGV_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton ib = e.Row.FindControl("btnShowDepend") as ImageButton;
            if (ib != null)
            {
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = ib.UniqueID;
                trigger.EventName = "Click";
                TasksUpdatePanel.Triggers.Add(trigger);
            }
        }
    }
