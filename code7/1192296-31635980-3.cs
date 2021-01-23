    private void Form1_Load(object sender, EventArgs e)
    {
    	string[] cmdLineArgs = Environment.GetCommandLineArgs();
    	List<string> jpgFilenamesToAnalyze = new List<string>();
    
    	foreach (var arg in cmdLineArgs)
    	{
    		if (arg.Contains(".jpg") || arg.Contains(".jpeg"))
    		{
    			jpgFilenamesToAnalyze.Add(arg);
    		}
    	}
    
    	if (jpgFilenamesToAnalyze.Count > 0)
    	{
    		StringBuilder sbJPGFiles = new StringBuilder();
    		sbJPGFiles.AppendLine("Found " + jpgFilenamesToAnalyze.Count + " images to analyze:\n\nFiles:");
    
    		foreach (var jpgFilename in jpgFilenamesToAnalyze)
    		{
    			// YourGetEXIFDataMethod(jpgFilename)
    			sbJPGFiles.AppendLine(jpgFilename);
    		}
    
    		MessageBox.Show(sbJPGFiles.ToString());
    	}
    	else
    	{
    		MessageBox.Show("No images found to analyze");
    	}
    }
