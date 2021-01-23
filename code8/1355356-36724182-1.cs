    class MainClass
    {
        private static int Main(string[] args)
        {
            // add code to validate arguments
            if (args.Length == 0)
            {
                string line = null;
                string targetStart = "@{";
                string targetEnd = "}";
                string fileName = args[0];
    
                using (var reader = new StreamReader(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(targetStart))
                        {
                            while (!line.Equals(targetEnd))
                            {
                                // ---- stuff to do 
    
                            }
                            break;
                        }
                    }
                }
                return 1;
            }
            return 0;
        }
    }
