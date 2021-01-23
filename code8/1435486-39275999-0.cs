    //during initialise
    this.View.LongClick += View_LongClick;
    this.Oid = Guid.NewGuid();
    ...
    void View_LongClick(object sender, View.LongClickEventArgs e)
    {
        //pass in MapMarker Guid
        var data = ClipData.NewPlainText("name", Oid.ToString());
        // Start dragging and pass data
        ((sender) as View).StartDrag(data, new View.DragShadowBuilder(((sender) as View)), null, 0);
    }
