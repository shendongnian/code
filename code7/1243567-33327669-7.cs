    Guid sid = Guid.NewGuid();
    foreach(var p in ids){
        db.TempIDs.Add(new TempID{ SID = sid, Value = p });
    }
    db.SaveChanges();
 
    var qIDs = db.TempIDs.Where( x=> x.SID == sid );
    var myEntities db.MyEntities.Where( x => qIDs.Any( q.Value == x.Id) );
 
    // delete all TempIDs...
    db.SqlQuery("DELETE FROM TempIDs WHERE SID=@sid,
         new SqlCommandParameter("@sid", sid));
    
