    Dictionary<string, int> nameValuePairs = new Dictionary<string, int>();
            nameValuePairs.Add("A", 2);
            nameValuePairs.Add("B", 4);
            nameValuePairs.Add("D", 0);
            
            //A == 2 && D => this returns true, as A exists and it's value is 2 and D also exists
            int d = 0;
            if (nameValuePairs.ContainsKey("A") && nameValuePairs.TryGetValue("D", out d) && nameValuePairs.ContainsKey("D"))
            {
                Console.WriteLine("Test 1: True");
            }
            else
            {
                Console.WriteLine("Test 1: False");
            }
            //(A && B) OR C => this returns true, as both A and B exists on the list
            if ((nameValuePairs.ContainsKey("A") && nameValuePairs.ContainsKey("B")) || nameValuePairs.ContainsKey("C"))
            {
                Console.WriteLine("Test 2: True");
            }
            else
            {
                Console.WriteLine("Test 2: False");
            }
            //A && !B => this returns false, as A exists on the list but B as well (but B shouldn't)
            if (nameValuePairs.ContainsKey("A") && !nameValuePairs.ContainsKey("B")) 
            {
                Console.WriteLine("Test 3: True");
            }
            else
            {
                Console.WriteLine("Test 3: False");
            }
