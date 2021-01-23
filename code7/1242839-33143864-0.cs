    using(var tw = new StreamWriter(dirfile3, true))
    {
        foreach (string file in System.IO.Directory.GetFiles(txtpath3.Text, "*.*"))
        {
            tw.WriteLine("" + file + "");
        }
    }
