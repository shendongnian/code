    private void checkLastResart()
    {
        string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"Settings.txt");
        using(StreamReader sr = new StreamReader(file))
        {
            if (sr.ReadLine() == null)
            {
                sr.Close();
                MessageBox.Show(...)
                using(StreamWriter sw = new StreamWriter(file, false))
                {
                    sw.WriteLine("Conversion Complete Checkbox: 0");
                    sw.WriteLine("Default Tool: 0");
                    sw.WriteLine("TimeSinceResart: 0");
                    sw.Flush();
                }
            }
            else
            {
                ....
            }
        } // exit using block closes and disposes the stream
    }
