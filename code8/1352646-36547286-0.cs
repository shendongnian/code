    var result = 
         from us20 in Us20Repository.GetAll()
         join pj01 in Pj01Repository.GetAll() on 
             (us20.BKNM == "PJID" ?
                    us20.BKID :
                    (
                       us20.BKNM == "PSID" ?
                       (
                         (from pj02 in Pj02Repository.GetAll()
                         where
                              pj02.CLID == us20.CLID &&
                              pj02.PSID == us20.BKID
                         select new
                         {
                               PJID = pj02.PJID
                         }).First().PJID
                      ) :
                      ""
                   )
             )
         equals pj01.PJID
         select new
         {
             CLID = pj01.CLID
         };
