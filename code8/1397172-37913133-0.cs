            char[] ar = { 'a', 'h', 'm', 'a', 'd' };
            char[] ay = { 'a', 'y', 'm', 'a', 'd' };
            List<char> matches = new List<char>();
            if (ar.SequenceEqual(ay))
            {
                Console.WriteLine("Success");
            }
            else
            {
                for (int i = 0; i < ar.Count(); i++)
                {
                    if (ar[i] != ay[i])
                    {
                        matches.Add(ay[i]);
                    }
                }
                foreach (var matched in matches)
                {
                    Console.WriteLine("Failure: " + matched);
                }
            }
