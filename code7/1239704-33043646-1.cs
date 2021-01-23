    using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using (BufferedStream bs = new BufferedStream(fs))
    using (StreamReader sr = new StreamReader(bs))
    {
        var i = 0;
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            if (i == 4) //4th position = 5th line (3 header lines plus 2 data lines)
            {
                return line.split(',')[3];
            }
            i++;
        }
    }
