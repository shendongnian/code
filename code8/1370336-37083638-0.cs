    static void Main(string[] args)
    {
        string ut = "1Y, 4D, 01:23:45";
        string met = "T+4D, 01:11:32";
        string mission = "Kapollo";
        string vesselName = "Saturn K";
        string vesselModules = "Command/Service Module;Munar Excursion Module";
        string kerbals = "Valentina Kerman, Pilot;Jebediah Kerman, Pilot;Bill Kerman, Engineer;Bob Kerman, Scientist\n";
        string[] headerNames = { "UT:", "MET:", "Mission:", "Vessel:", "Modules:", "Crew:" };
        string[] headerData = new string[6] { ut, met, mission, vesselName, vesselModules, kerbals };
        StringBuilder builder = new StringBuilder("Mission Log Computer Initialized");
        builder.AppendLine();
        for (int index = 0; index < headerNames.Length; index++)
        {
            var items = headerData[index].Split(';');   //splits the string when a ';' is present
            if (items.Length > 1)   //if there is more than one item in a string, do this:
            {
                builder.AppendFormat("{0,-12} {1,-46}", headerNames[index], items[0]);   //writes headerName as usual. Not sure what items[0] does
                builder.AppendLine();
                for (int i = 1; i < items.Length; i++)  //for every item in the string, increment 'i' by 1
                {
                    // Render the following items.
                    builder.AppendFormat("{0,-12} {1,-46}", string.Empty, items[i]);
                    builder.AppendLine();
                    //^^^writes a blank entry where headerName would print using string.Empty, and then writes 'i', but I'm not sure how 'i' ends up containing multiple strings
                }
            }
            else
            {
                builder.AppendFormat("{0,-12} {1,-46}", headerNames[index], headerData[index]);    //otherwise, do this
                builder.AppendLine();
            }
        }
        string result = builder.ToString();
        // Write result to a file
    }
