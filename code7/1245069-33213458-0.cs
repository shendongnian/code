    @{
        string sessionName = Context.Session.GetString("name");
        if (sessionName != null)
        {
            <p>@sessionName</p>
        }
    }
