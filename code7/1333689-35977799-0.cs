    void Main()
    {
    	MoveFiles(@"c:\Temp\MoveTest", @"C:\Temp\MoveTest1");
    }
    
    public void MoveFiles(string fromDir, string toDir)
    {
    	int ImageCounter = 1;
    
    	// Take a snapshot of the file system.
    	System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(fromDir);
    	IEnumerable<System.IO.FileInfo> ImageFilePaths = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly); 
    
    	foreach (var Image in ImageFilePaths)
    	{
    		{
    			Console.WriteLine(Image);
    			Console.WriteLine(toDir + @"\" + ImageCounter + ".jpeg");
    			File.Move(Image.FullName, toDir + @"\" + ImageCounter + ".jpeg");
    			ImageCounter++;
    		}
    	}
    }
