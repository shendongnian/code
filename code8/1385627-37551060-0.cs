    List<A> As = ... //This is a list in memory
    
    //Get all ids of As
    var A_ids = As.Select(x => x.ID).ToList();
    //Get all ids that are in both As (memory) and TableB (database)
    //We put then in a HashSet for performance reasons
    var ids_in_tableB_also =
       new HashSet<int>(
           db.TableB
           .Where(x => A_ids.Contains(x.ID))
           .Select(x => x.ID)
           .AsEnumerable());
    var rest_of_As = As.Where(x => !ids_in_tableB_also.Contains(x)).ToList();
