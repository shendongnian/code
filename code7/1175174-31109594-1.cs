    var entgr = (from fx in MainOnline.MA_TelUsers
                     where fx.TE_SectionID != null
                     group fx by fx.TE_SectionID into ids
                               select new
                               {
     Section = ids.TE_SectionID,
                          TelPhone =ids.Aggregate((a, b) => 
                                           new {TelPhone = (a.TelPhone + ", " + b.TelPhone ) }).TelPhone 
                                   
                               });
