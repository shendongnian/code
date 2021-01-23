    var state  = "WA";
    var region = "Western";
    var type   = "Laptop";
    var xElement = XElement.Parse(@"<Settings>
        <Server>
            <Id>1</Id>
            <Name>SRV123456</Name> 
            <Par Type='Desktop' Region='Western'>12</Par>
            <Par Type='Laptop' Region='Western'>15</Par>
            <Par Type='Desktop' Region='Eastern'>22</Par>
            <Par Type='Laptop' Region='Eastern'>25</Par>
            <State>WA</State>
        </Server>
    </Settings>");
    foreach (XElement server in xElement.XPathSelectElements(
                String.Format("//Server[State='{0}']", state)))
    {
        Console.WriteLine(server);
        // In your sample the Western/Desktop is the first element
        // If you want a specific Par element, you should query again with that filter
        foreach (XElement par in server.XPathSelectElements(
                    String.Format("Par[@Region='{0}' and @Type='{1}']", region, type)))
            Console.WriteLine(par.Value); ;
    }
