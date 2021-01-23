    protected void Page_Load(object sender, EventArgs e)
    {
        List<formData> attendees;
    
        if(Session["attendees"] == null)
        {
            attendees = new List<formData>();
            // your logic logic ...
            Session["attendees"] = attendees;
        }
        else
        {
            var attendees = (List<formData>)Session["attendees"];
            // your logic ...
            Session["attendees"] = attendees;
        }
    }
