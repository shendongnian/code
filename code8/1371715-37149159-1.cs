    private void Form1_Load(object sender, EventArgs e)
    {
        var eventsProperty = dataGrid1.GetType().GetProperty("Events",
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        EventHandlerList events = eventsProperty.GetValue(dataGrid1) as EventHandlerList;
        var eventsNodeClickedKeyField = dataGrid1.GetType().GetField("EVENT_NODECLICKED",
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Static);
        object eventsNodeClickedKey = eventsNodeClickedKeyField.GetValue(null);
        events.AddHandler(eventsNodeClickedKey, new EventHandler(dataGrid1_NodeClicked));
    }
    private void dataGrid1_NodeClicked(object sender, EventArgs e)
    {
        var grid = sender as DataGrid;
        var point = grid.PointToClient(MousePosition);
        var hti = grid.HitTest(point);
        grid.NavigateTo(hti.Row, "RelationName");
    }
