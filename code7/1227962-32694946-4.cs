    if (Master.MasterId != 0)
    {
         var oldDetails = Dba.Detail.Where(det => det.MasterId == Master.MasterId);
         foreach (var olddetail in oldDetails)
         {
               // don't call remove here just update new values in those properties which are changed like this   
         }
         //no need to set modified state because this olddetail is in current request
    }
    Dba.SaveChanges();}
