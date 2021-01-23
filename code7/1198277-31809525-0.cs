     startInfo = new ProcessStartInfo(fileName);
    
        if (File.Exists(fileName))
        {
            i = 0;
            foreach (String verb in startInfo.Verbs)
            {
                // Display the possible verbs.
                Console.WriteLine("  {0}. {1}", i.ToString(), verb);
                i++;
            }
        }
