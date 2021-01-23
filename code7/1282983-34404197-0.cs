    int headerCount = 1;
            int zoneNumber = 0;
            string[] lines = File.ReadAllLines(@"C:\temp\tcam\test.txt");
            foreach (string line in lines)
            {
                headerCount++;
                if (headerCount == 6)
                {
                    string[] zonelocation = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    int zoneCount = 0;
                    string lastVal = "";
                    foreach (var x in zonelocation)
                    {
                        zoneCount++;
                        if (lastVal.ToLower() == "top" && x.ToLower() == "sys") zoneCount--;
                        if (x.ToLower() == "zoning") zoneNumber = zoneCount - 1;
                        lastVal = x;
                    }
                }
                if (headerCount > 8)
                {
                    string[] zoneinfo = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    if (zoneinfo.Any())
                    {
                        string[] zoneData = zoneinfo[zoneNumber].Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine($"Fwd Eng {zoneinfo[1]}, Direction {zoneinfo[2]}, Used {zoneData[0]}, Total {zoneData[1]}");
                    }
                }
            }
