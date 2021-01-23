    var idMax = db.TableName.Max(t=>t.id);
    var rand = new Random();
    var randIds = Enumerable.Range(0,4).Select(i => rand.Next(1,idMax));
    var query=db.TableName.Where(t=>false);
    
    foreach(int id in randIds)
    {
       query=query.Concat(db.TableName.OrderBy(t=>t.id).Where(t=>t.id>=id).Take(1));   
    }
    var randomRecords=query.ToList();
