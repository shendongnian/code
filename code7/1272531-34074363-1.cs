    var result = 
         from m in db.HALAQATI_VIEW_GetAllMosques
         where m.Emp_ID == id
         select new {
             MsqID = m.MSQ_ID,
             MsqName = m.MSQ_Name, 
             Rings = from r in db.HALAQATI_VIEW_GetAllRings
                 where m.MSQ_ID == r.MSQ_ID
                 where m.Emp_ID == r.Emp_ID  // is this even necessary?
                 select new {
                     r.Ring_ID,
                     ...
                     Students = from s in db.HALAQATI_VIEW_GetAllStudents
                         where r.Ring_ID == s.Ring_ID
                         select s
                 }
         };
    return new { Mosques = result };  
