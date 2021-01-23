      var pricesFromLeftJoin =
                        (from np in newPrices
                         join op in oldPrices on np.Id equals op.Id into subOldPrices
                         from subPrice in subOldPrice.DefaultIfEmpty()
                         where subPrice == null || (subPrice != null && subPrice .Price != np.Price)
                         select np).ToDictionary(x => x.Id, x => x.Price);
            
      var pricesFromLeftJoin_compactForm =
                    (from np in newPrices
                     from op in oldPrices.Where(op => (op.Id == np.Id)).DefaultIfEmpty() 
                     where op == null || (op != null && op.Price != np.Price)
                     select np).ToDictionary(x => x.Id, x => x.Price);
