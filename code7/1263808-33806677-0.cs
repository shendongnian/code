    private void Log(string s)
    {
        string file = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\'));
        file += "\\logs\\";
        if (!Directory.Exists(file))
            Directory.CreateDirectory(file);
        file += DateTime.Now.Date.Year.ToString();
        file += "-" + DateTime.Now.Date.Month.ToString();
        file += "-" + DateTime.Now.Date.Day.ToString();
        file += (".log");
        FileStream fs = new FileStream(file, FileMode.Append);
        StreamWriter sw = new StreamWriter(fs);
        
        sw.WriteLine(DateTime.Now.Hour.ToString("00")+ ":" +
                     DateTime.Now.Minute.ToString("00") + ":" +
                     DateTime.Now.Second.ToString("00") + " " + s);
        sw.Close();
        fs.Close();
    }
