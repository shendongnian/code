    string[] paths = new string[4].Select(x => System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).ToArray();
    string[0] += ...;
    string[1] += ...;
    string[2] += ...;
    string[3] += ...;
  
    foreach (string path in paths)
    {
        using (FileStream fs = File.OpenWrite(path))
        {
            // do stuff
        }
    }
