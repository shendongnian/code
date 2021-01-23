    string WorkDir = @"C:\Users\rwong\Desktop\TestFiles";
    Directory.SetCurrentDirectory(WorkDir);
    String[] SubWorkDir = Directory.GetDirectories(WorkDir);
    
    foreach (string subdir in SubWorkDir)
    {
        string[] filelist = Directory.GetFiles(subdir);
        for(int f = 0; f < filelist.Length; f++)
        {
            if (filelist[f].ToLower().EndsWith(".pdf") || filelist[f].EndsWith(".PDF"))
            {
                PDFReader reader = new Pdfreader(filelist[f]);
                bool PDFCheck = reader.IsOpenedWithFullPermissions;
                reader.CLose()l
                if(!PDFCheck) 
                {
                    string PNGPath = Path.ChangeExtension(filelistf], ".png");
                    string PDFfile = '"' + filelist[f] + '"';
                    string PNGfile = '"' + PNGPath + '"';
                    string arguments = string.Format("{0} {1}", PDFfile, PNGfile);
    				Process p = new Process();
    				p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.EnableRaisingEvents = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.startInfo.FileName = "C:\Program Files\ImageMagick-6.9.2-Q16\convert.exe";
                    p.startInfo.Arguments = arguments;
    				p.OutputDataReceived += new DataReceivedEventHandler(Process_OutputDataReceived);
    				//You can receive the output provided by the Command prompt in Process_OutputDataReceived
                    p.Start();
                }
          }
    }
    
    private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
    	if (e.Data != null)
    	{
    		string s = e.Data.ToString();
    		s = s.Replace("\0", string.Empty);
    		//Show s 
    		Console.WriteLine(s);
    	}
    }
		
