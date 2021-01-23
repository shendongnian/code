    private readonly object _locker = new object();
    // write the file
    private void WriteToFile(string info, string path, string tr)
    {
        Monitor.Enter(this._locker);
        try
        {
            if (!File.Exists(path + @"\" + @tr))
            {
                var myFile =
                File.Create(path + @"\" + @tr);
                myFile.Close();
                TextWriter tw = new StreamWriter(path + @"\" + @tr, true);
                tw.WriteLine(info, true);
                tw.Close();
            }
            else if (File.Exists(path + @"\" + @tr))
            {
                TextWriter tw = new StreamWriter(path + @"\" + @tr, true);
                tw.WriteLine(info);
                tw.Close();
            }
        }
        finally
        {
            Monitor.Exit(this._locker);
        }
    }
