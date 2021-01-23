            List<string> file1Parsed = new List<string>();
            List<string> file2Parsed = new List<string>();
            List<string> file3Parsed = new List<string>();
            using (StreamReader readerFile1 = new StreamReader(@"c:\file1.txt"))
            {
                while (!readerFile1.EndOfStream)
                {
                    file1Parsed.Add(readerFile1.ReadLine());
                }
            }
            using (StreamReader readerFile2 = new StreamReader(@"c:\file2.txt"))
            {
                while (!readerFile2.EndOfStream)
                {
                    file2Parsed.Add(readerFile2.ReadLine());
                }
            }
            using (StreamReader readerFile3 = new StreamReader(@"c:\file3.txt"))
            {
                while (!readerFile3.EndOfStream)
                {
                    file3Parsed.Add(readerFile3.ReadLine());
                }
            }
            char[] firstSet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
            char[] secondSet = { 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var file1InFile2 = file1Parsed.Where(y=> y.ToUpper().IndexOfAny(firstSet) == 0).Select(x => x);
            var file1InFile3 = file1Parsed.Where(y => y.ToUpper().IndexOfAny(secondSet) == 0).Select(x => x);
            using (StreamWriter writer = new StreamWriter(@"C:\notExists.txt"))
            {
                foreach (var file in file1InFile2)
                {
                    if (!file2Parsed.Contains(file.Trim()))
                    {
                        writer.WriteLine("This email needs to be added to file2: " + file);
                    }
                }
                foreach (var file in file1InFile3)
                {
                    if (!file3Parsed.Contains(file.Trim()))
                    {
                        writer.WriteLine("This email needs to be added to file3: " + file);
                    }
                }
                foreach (string file in file2Parsed)
                {
                    if (!file1InFile2.Contains(file.Trim()))
                    {
                        writer.WriteLine("This email needs to be added to file1: " + file);
                    }
                }
                foreach (string file in file3Parsed)
                {
                    if (!file1InFile3.Contains(file.Trim()))
                    {
                        writer.WriteLine("This email needs to be added to file1: " + file);
                    }
                }
            }
