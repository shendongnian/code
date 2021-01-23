    foreach (string file in System.IO.Directory.GetFiles(txtpath3.Text, "*.*"))
    {
       TextWriter tw = new StreamWriter(dirfile3, true);
       tw.WriteLine("" + file + "");
       tw.Close();
    }
