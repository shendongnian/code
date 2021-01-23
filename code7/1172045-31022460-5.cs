    var tmpfile = Path.GetTempPath() + ".mytmpfile.txt";
    File.Copy(path, tmpfile, true);
    using (var sw = new StreamWriter(path, false, Encoding.UTF8))
    {
        using (var sr = new StreamReader(tmpfile, true))
        {
             var line = string.Empty;
             while ((line = sr.ReadLine()) != null)
             {
                 if (!line.Trim().StartsWith("smth"))
                    sw.WriteLine(line);
             }
        }
        File.Delete(tmpfile);
    }
