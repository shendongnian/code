    var tmpfile = Path.GetTempPath() + ".mytmpfile.txt";
    File.Copy(path, tmpfile, true);
    using (var sw = new StreamWriter(path, false, Encoding.UTF8))
    {
        using (var sr = new StreamReader(tmpfile, true))
        {
             var line = string.Empty;
             while ((line = sr.ReadLine()) != null)
             {
                 if (line.StartsWith("smth"))
                    sw.WriteLine(line.Substring(4)); // 4 is the length of the "smth"
                 else
                    sw.WriteLine(line);
             }
        }
        File.Delete(tmpfile);
    }
