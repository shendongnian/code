    List<string> goodPing = new List<string>();
    List<string> badPing = new List<string>();
    Ping ping = new Ping();
    foreach (string singleComputer in computerArray)
    {
        // Ping all computers
        PingReply pingresult = ping.Send(singleComputer);
        if (pingresult.Status.ToString() == "Success")
        {
             goodPing.Add(singleComputer);
        }
        else if (pingresult.Status.ToString() != "Success")
        {
             badPing.Add(singleComputer);
        }
    }
