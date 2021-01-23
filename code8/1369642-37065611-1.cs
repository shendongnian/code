        string ut = "1Y, 4D, 01:23:45";
        string met = "T+4D, 01:11:32";
        string vesselName = "Saturn K";
        string vesselModules = "Command/Service Module;Munar Excursion Module";
        string kerbals = "Valentina Kerman, Pilot;Jebediah Kerman, Pilot;Bill Kerman, Engineer;Bob Kerman, Scientist";
        string[] headerNames = { "UT:", "MET:", "Vessel:", "Modules:", "Crew:" };
        string[] headerData = new string[5] { ut, met, vesselName, vesselModules, kerbals };
        for (int index = 0; index < headerNames.Length; index++)
        {
            // Split data if there are more than one.
            var items = headerData[index].Split(';');
            if (items.Length > 1)
            {
                // We got more than one item. Render first item.
                Console.WriteLine("{0,-12} {1,-46}", headerNames[index], items[0]);
                for (int i = 1; i < items.Length; i ++)
                {
                    // Render the following items.
                    Console.WriteLine("{0,-12} {1,-46}", string.Empty, items[i]);
                }
                
            }
            else
            {
                // Only one item. Render it as usual.
                Console.WriteLine("{0,-12} {1,-46}", headerNames[index], headerData[index]);
            }
        }
