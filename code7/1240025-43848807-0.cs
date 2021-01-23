    var host = HttpContext.Current.Request.Headers["HOST"];
    var machineHostName = Dns.GetHostName();
    if(host.ToLower().Equals(machineHostName.ToLower()))
    {
        // Perform your action here.
    }
