    static void Main(string[] args)
    {
        string ut = "1Y, 4D, 01:23:45";
        string met = "T+4D, 01:11:32";
        string vesselName = "Saturn K";
        string vesselModules = "Command/Service Module \nMunar Excursion Module";
        string kerbals = "Valentina Kerman, Pilot; \nJebediah Kerman, Pilot; \nBill Kerman, Engineer; \nBob Kerman, Scientist";
        string[] headerNames = { "UT:", "MET:", "Vessel:", "Modules:", "Crew:" };
        string[] headerData = new string[5] { ut, met, vesselName, vesselModules, kerbals };
         for (int index = 0; index < headerNames.Length; index++) {
             if(headerNames[index] == "Modules:" || headerNames[index] == "Crew:") {
                string dataStr = headerData[index];
                var data = dataStr.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("{0,-12} {1,-46}", headerNames[index], data[0] ?? string.Empty);
                for (int i = 1; i < data.Length; i++) {
                    Console.WriteLine("{0,-12} {1,-46}", string.Empty, data[i]);
                }
             } else {
                Console.WriteLine("{0,-12} {1,-46}", headerNames[index], headerData[index]);
             }
        }
    }
    
