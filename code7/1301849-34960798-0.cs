    List<string> goodPings = new List<string>();
    List<string> badPings = new List<string>();
    foreach (string singleComputer in computerArray)
            {
                // Ping all computers
                Ping ping = new Ping();
                PingReply pingresult = ping.Send(singleComputer);
    
                if (pingresult.Status.ToString() == "Success")
                {
                   goodPings.Add(singleComputer); // and don't forget to use the variable singleComputer here, not the literal string "singleComputer".
                }
                else if (pingresult.Status.ToString() != "Success")
                {
                   badPings.Add(singleComputer);
                }
            }
