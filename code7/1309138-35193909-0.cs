    class Program
        {
            static void Main(string[] args)
            {
               
    
                String batchOfevents = "L,030216,182748,00,FF,I,00,030216,182749,00,FF,I,00,030216,182750,00,FF,I,00,030216,182751,00,FF,I,00,030216,182752,00,FF,I,00,030216,182753,00,FF,I,00";
    
                // take out the "L," to start processing by finding the index of the correct comma to slice. 
                batchOfevents = batchOfevents.Substring(2);
    
                String output = "";
                int index = 0;
                int counter = 0;
                while (GetNthIndex(batchOfevents, ',', 6) != -1)
                {
    
                counter++;
    
                if (counter == 1){
                    index = GetNthIndex(batchOfevents, ',', 6);
                    output += "L, " + batchOfevents.Substring(0, index) + " - 1st event\n";
                    batchOfevents = batchOfevents.Substring(index + 1);
    
                } else if (counter == 2) {
                    index = GetNthIndex(batchOfevents, ',', 6);
                    output += "L, " + batchOfevents.Substring(0, index) + " - 2nd event\n";
                    batchOfevents = batchOfevents.Substring(index + 1);
    
                }
                else if (counter == 3)
                {
                    index = GetNthIndex(batchOfevents, ',', 6);
                    output += "L, " + batchOfevents.Substring(0, index) + " - 3rd event\n";
                    batchOfevents = batchOfevents.Substring(index + 1);
    
                } else {
    
                    index = GetNthIndex(batchOfevents, ',', 6);
                    output += "L, " + batchOfevents.Substring(0, index) + " - " + counter + "th event\n";
                    batchOfevents = batchOfevents.Substring(index + 1);
    
                }
                
    
                }
    
    
                output += "L, " + batchOfevents + " - last event\n";
    
    
                Console.WriteLine(output);
            }
    
            public static int GetNthIndex(string s, char t, int n)
            {
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == t)
                    {
                        count++;
                        if (count == n)
                        {
                            return i;
                        }
                    }
                }
                return -1;
            }
        }
