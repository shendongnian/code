    using (StreamWriter sw = File.AppendText(path))
    {
        using (StreamReader sr = new StreamReader(ms))
        {
            while (sr.Peek() >= 0)
            {
                string l = sr.ReadLine();
                sw.WriteLine(l);
            }
        }
    }
