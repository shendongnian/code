    protected void repMonths_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // We only care if the repeater item is part of the <ItemTemplate>
        if(e.Item.ItemType == ListItemType.Item)
        {
            // Get the month
            Label lblMonth = (Label)e.Item.FindControl("lblMonth");
            // Get the events for the month
            var eventList = from e in allCalendarEvents
                            where e.start.Month == lblMonth.Text
                            select e;
            // Bind your events to the inner repeater
            Repeater repInnerEvent = (Repeater)e.Item.FindControl("repInnerEvent");
            repInnerEvent.DataSource = eventList
            repInnerEvent.DataBind();
        }
    }
