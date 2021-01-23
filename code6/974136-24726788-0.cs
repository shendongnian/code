            string myString = "the quick brown fox jumps over the lazy dog";
            byte[] bytes = Encoding.UTF8.GetBytes(myString);
            int[] counts = new int[256];
            foreach (var b in bytes)
            {
                counts[(int)b]++;
            }
            for (int i = 0; i < 256; i++)
            {
                if (counts[i] > 0)
                {
                    Console.WriteLine("{0} - {1}", (char)(byte)i, counts[i]);
                }
            }
