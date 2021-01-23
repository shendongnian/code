    if (Session["Grid"] != null)
    {
        var b  = new ControllerB ();
        b.CallMethod(Session["Grid"]);
    }
    ...
    public object CallMethod(string grid)
    {
        //do your thing
    }
