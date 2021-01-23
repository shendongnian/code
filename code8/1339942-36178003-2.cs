	using System.Threading.Tasks;
	public void SaveCSV(string file, string fileName)
	{
		var csv = JsonConvert.DeserializeObject<List<SecurityFile>>(file);
		using (ApplicationDbContext db = ApplicationDbContext.Create())
		{
            var now = DateTime.Now;
			Parallel.Foreach(csv, item => {
				item.DateSubmitted = now;
				item.FileName = fileName;
			})
            //Attach the Entities all at once
            db.SecurityFiles.AddRange(csv);
		 
		    //Saves it to SQL Database
		    db.SaveChanges();
		}
	}
