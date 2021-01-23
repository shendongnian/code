	    var assembly = Assembly.GetExecutingAssembly();	    
	    var resourceName = "<ProjectName>.<FolderName>.UsersList.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var csv = new CsvReader(reader);
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.IgnoreHeaderWhiteSpace = true;
                    csv.Configuration.IgnoreQuotes = false;
                    csv.Configuration.IsHeaderCaseSensitive = false;
                    csv.Configuration.ThrowOnBadData = true;
                    csv.Configuration.QuoteAllFields = true;
                    csv.Configuration.RegisterClassMap<UsersClassMap>();
                    csv.Configuration.IgnoreReadingExceptions = true;
                    csv.Configuration.SkipEmptyRecords = false;
                    List<User> records = csv.GetRecords<User>().ToList();
		    
		            foreach (User user in records)
		            {
			            bt.Create(user.FFirstName, user.lastName, user.Description, user.Password, user.OU, user.Group);
		            }
                }
            }
	public class User
    	{
        	public string FFirstName { get; set; }
        	public string LastName { get; set; }
        	public string Description { get; set; }
        	public string Password { get; set; }
        	public string OU { get; set; }
        	public string Group { get; set; }
    	}
	public class UsersClassMap : CsvClassMap<User>
    	{
            public UsersClassMap()
        	{
            	   Map(x => x.FFirstName).Index(0).Name("FFirstName");
                   Map(x => x.LastName).Index(1).Name("LastName");
                   Map(x => x.Description).Index(2).Name("Description");
                   Map(x => x.Password).Index(3).Name("Password");            
                   Map(x => x.OU).Index(4).Name("OU");    
                   Map(x => x.Group).Index(5).Name("Group");    
                }
        }
    
