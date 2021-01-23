    public Form1()
    {
        InitializeComponents();
        foreach(Control c in Controls)
           SetCursorOnControls(c, Cursors.Hand); // or SetCursorEventsOnControls
    }
