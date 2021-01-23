            string[] names = { "dSSB", "dGEN", "dLYM", "dLUD", "dGGC", "dMAC", "dMMB" };
            for (int i = 0; i < names.Length; i++)
            {
                buildings.Add(i, names[i]);
            }
            foreach (var building in buildings)
            {
                Console.WriteLine(building);
            }
