    var result = from permission in db.permissions
                 join business in db.business
                 on permission.permid equals business.busid into b
                 from bus in b.DefaultIfEmpty()
                 where permission.anotherid  == 17
                 select new DTO_business()
                                {
                                     BusinessID = bus != null ? bus.busid : 0,
                                     BusinessName = bus != null ? bus.busname : String.Empty
                                };
             
             
