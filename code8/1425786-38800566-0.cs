      public void FileProcess()
        {
            Process proc = Process.GetCurrentProcess();
            int i = 0;
            while (i < 40)
            {
                Console.WriteLine(" i: {0} - Private memory: {1} KB- Memory Used: {2} KB", i,
                    proc.PrivateMemorySize64/1024.0, GC.GetTotalMemory(true)/1024.0);    
                var path = "test0.txt";
                var path2 = "test2.txt";
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                using (StreamWriter outputFile = new StreamWriter(path2))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var text = ProcessLine(line, i);
                        outputFile.WriteLine(text);
                    }
                }
                i++;
                // Collect all generations of memory.
                // GC.Collect(); //you need not
            } //while
        }
        private string ProcessLine(string text, int i)
        {
            string Value3 = @"(.*?)&";
            string Value4 = string.Format("$1#{0}#", i);
            var strFile42 = Regex.Replace(text, Value3, Value4);
            return strFile42;
        }
    }
