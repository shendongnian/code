    using System.Text;
    //...
    StringBuilder text = null;
    using (StreamReader sr = new StreamReader(file, Encoding.Default))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            text.Append(line);
            backgroundWorker1.ReportProgress(text.Length);
        }
    }
    // ...
    // Do something with the file you have read in.
    Console.WriteLine(text.ToString());
