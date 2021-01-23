    @{
    var sessionName = new Byte[20];
    bool nameOK = Context.Session.TryGetValue("name", out sessionName);
    
    if (nameOK)
    {
        string result = System.Text.Encoding.UTF8.GetString(sessionName);
        <p> @result</p>
    }
    }
