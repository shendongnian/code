    if (_hostingEnvironment.IsProduction())
    {
            var command = "-c 'convert " + filePath + " -resize 960x960 -quality 70 " + filePath + "'";
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = command;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.Start();
    }
