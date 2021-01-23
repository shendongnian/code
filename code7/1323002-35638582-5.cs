	void Main()
	{
		// given a list of files from db
		DataTable dataTable = new DataTable("x");  
		dataTable.Columns.Add("file", typeof(string));  
		dataTable.Rows.Add("HaxLogs.txt");dataTable.Rows.Add("swapfile.sys");dataTable.Rows.Add("four.txt");
		var directory = "c:\\";
				var directoryFilesWithPaths = Directory.GetFiles(directory)
		        .Select( x=> new FileEntry { Path = x, FileName = x.Substring(x.LastIndexOf('\\') + 1)});		                                     
				var directoryFiles = directoryFilesWithPaths.Select(x => x.FileName).ToList();
				var filesList = (from DataRow dr in dataTable.Rows
								select dr[0].ToString()).ToList();
								
				var filesToProcess = directoryFiles.Except(filesList);
				foreach(var file in filesToProcess)
				{
					// process file here
						var fileToDelete = directoryFilesWithPaths.Where(x=>x.FileName == file).Select(x=>x.Path).First();
					Console.WriteLine(fileToDelete);
				}	   
			}
			
			public class FileEntry
			{
				public string FileName {get;set;}
				public string Path {get;set;}
			}
	
