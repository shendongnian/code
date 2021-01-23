    foreach (string fileName in files)
    {
        var temp = fileName;
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = @"C:\Program Files\cli-tool\cli.exe";
        startInfo.Arguments = "-i " + "\"" + fileName + "\"" + " -o " + "\"" + label2.Text + "\\" + Path.GetFileName(fileName) + "\"" + " -s -t";
        process.StartInfo = startInfo;
        process.EnableRaisingEvents = true;
        process.Start();
        process.Exited += delegate
        {
            File.Delete(temp);
            progressBar1.Increment(1);
        };
    }
