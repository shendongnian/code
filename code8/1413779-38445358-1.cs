    List<formData> attendees;
    if(Session["attendees"] == null)
    {
        attendees = new List<formData>();
        // logic ...
        Session["attendees"] = attendees;
    }
    else
    {
        var attendees = (List<formData>)Session["attendees"];
        // logic ...
    }
