          StreamReader sr = new StreamReader(filename);
           // String[,] wordlist = null;
            var wordList = new List<string[]>();
            //int Row = 0;
            while(!sr.EndOfStream)
            {
                String[] header = sr.ReadLine().Split(',');
                //wordlist[Row, 0] = header[Row];
                wordList.Add(header); 
                //Row++;
            }
