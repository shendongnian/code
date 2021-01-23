    string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"Settings.txt");
 
    // First read the two lines in memory
    string[] lines = File.ReadAllLines(file);
    // then use the StreamWriter that locks the file
    using(StreamWriter sw = new StreamWriter(file))
    {
         lines[2] = "TimeSinceResart: " + timeSinceRestart;
         foreach (string s in lines)
             sw.WriteLine(s);
    }
