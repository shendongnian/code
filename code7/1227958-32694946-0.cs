        if (Master.MasterId != 0)
                        {
                            var oldDetails =
                                Dba.Detail.Where(det => det.MasterId == Master.MasterId);
                            foreach (var olddetail in oldDetails)
                            {
                                // don't call remove here just update new values in those properties which are changed like this
    olddetail.prop1=Master.prop1;
                            }
    //no need to set modified state because this olddetail is in current request
                         }
            Dba.SaveChanges();}
