    void Main()
    {
    	var csvlines = File.ReadAllLines(@"M:\smdr(backup08-06-2015).csv");
    var csvLinesData = csvlines.Skip(1).Select(l => l.Split(',').ToArray());
    
    // i am assuming that line[7] is the Party1Name Column
    // now you have a (sorted) group with n "members" (ACC, Sales, ..., n )
    var groupOfUser = from line in csvLinesData 
    				  where  !line[12].Contains("VM") && !line[12].Contains("Voice Mail")
                      group line by line[12] into newGroup 
                      orderby newGroup.Key 
                      select newGroup;
    
    // The Key of your userOfGrp is the Name e.g. "ACC"
    // i am assuming that x[4] is the direction Column
    // I count all I or O and put them into the new User
    var user = (from userOfGrp in groupOfUser
                select
                    new User()
                        {
                            CSRName = userOfGrp.Key,
                            Incomming = userOfGrp.Count(x => x[4] == "I"),
                            Outgoing = userOfGrp.Count(x => x[4] == "O")
                        }).ToList();
    					user.Dump();
    }
    
    class User
    {
        public string CSRName;
        public int Outgoing;
        public int Incomming;
        public int calltransfer;
    }
