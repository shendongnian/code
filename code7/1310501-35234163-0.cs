    public static void WriteToExcelMethod(DateTime dt, string str, TimeSpan ts)
    {
        string path = @"c:\temp\MyTest.csv";
        string line = String.Format(@"""{0}"",""{1}"",""{2}""", dt, str, ts);
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(line);
        }
    }
