    static void Main()
    {
        try { File.Delete(@"c:\tmp\test.zip"); }
        catch { }
        var sw = Stopwatch.StartNew();
        using (var zip = new ZipFile(@"c:\tmp\test.zip"))
        {
            zip.UseZip64WhenSaving = Zip64Option.Always;
            for (int i = 0; i < 200000; ++i)
            {
                string filename = "foo" + i.ToString() + ".txt";
                byte[] contents = Encoding.UTF8.GetBytes("Hello world!");
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                zip.AddEntry(filename, contents);
            }
            zip.Save();
        }
        Console.WriteLine("Elapsed: {0:0.00}s", sw.Elapsed.TotalSeconds);
        Console.ReadLine();
    }
