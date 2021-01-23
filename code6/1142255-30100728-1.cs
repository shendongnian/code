    var q = (from a in context.MyDBEntity
             where {some condition}
             select new 
             {
                 a.LocalDocumentDate, 
                 a.UTCDocumentDate
             })
             .AsEnumerable()
             .Select(a => new MyDomainClass 
             {
                 DocumentDateInDateTimeOffsetFormat = GetDTOFromLocalAndUTC(a.LocalDocumentDate, a.UTCDocumentDate)
             });
