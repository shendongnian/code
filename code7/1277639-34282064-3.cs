         private IQueryable SearchFilterCondition(string param,string q
            ,string filter,string value,string sort,string dir)
         {
           var searchXpr = SearchXpr(param, q);
           var filterXpr = FiltertXpr(filter, value);
           IQueryable<EmailAflAwmMessageDM>
           EmailAflAwmMessagejc = db.EmailAflAwmMessage.Where(filterXpr).Where(searchXpr);
           return SortXpr(EmailAflAwmMessagejc, sort, dir);
         }
