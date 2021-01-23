	void Main()
	{
		// given a list of files from db
		DataTable dataTable = new DataTable("x");  
		dataTable.Columns.Add("file", typeof(string));  
		dataTable.Rows.Add("HaxLogs.txt");dataTable.Rows.Add("swapfile.sys");dataTable.Rows.Add("four.txt");
	    var directory = "c:\\";
        var directoryFilesWithPaths = Directory.GetFiles(directory)
		        .Select( x=> new FileEntry { Path = x, FileName = Path.GetFileName(x)});
		                                     
				var directoryFiles = directoryFilesWithPaths.Select(x => x.FileName).ToList();
				var filesList = (from DataRow dr in dataTable.Rows
								select dr[0].ToString()).ToList();
								
				var filesToProcess = directoryFiles.Except(filesList);
            foreach (var file in filesToProcess)
            {
                // process file here
                
                Console.WriteLine(file);
            }
}
			 
	
