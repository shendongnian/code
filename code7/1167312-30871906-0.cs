    var csvlines = File.ReadAllLines(@"M:\smdr(backup08-06-2015).csv");
    var csvLinesData = csvlines.Skip(1).Select(l => l.Split(',').ToArray());
    
    // i am assuming that line[7] is the Party1Name Column
    // now you have a (sorted) group with 4 "members" (ACC, Sales, ... )
    var groupOfUser = from line in csvLinesData 
                      group line by line[7] into newGroup 
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
