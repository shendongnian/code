	void Main()
	{
		// given a list of files from db
		DataTable dataTable = new DataTable("x");  
		dataTable.Columns.Add("file", typeof(string));  
		dataTable.Rows.Add("HaxLogs.txt");dataTable.Rows.Add("swapfile.sys");dataTable.Rows.Add("four.txt");
	    var directory = "c:\\";
        var filesList = (from DataRow dr in dataTable.Rows
                             select dr[0].ToString()).ToList();
        var filesToProcess = Directory.GetFiles(directory).SelectMany(x => filesList.Where(s => x.EndsWith(s)));
            foreach (var file in filesToProcess)
            {
                // process file here
                
                Console.WriteLine(file);
            }
}
			 
	
