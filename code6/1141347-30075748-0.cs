    using (var mappedFile1 = MemoryMappedFile.CreateFromFile(filePath))
        {
            using (Stream mmStream = mappedFile1.CreateViewStream())
            {
                using (StreamReader sr = new StreamReader(mmStream, ASCIIEncoding.ASCII))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string lineWords = line.Split(' ');
                        lineWords[0] = number;
                        lineWords[1] = name; //and so on..
                    }
                }  
            }
        }
