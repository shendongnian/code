    (from p in _context.epc_parts
                         join trans in _context.epc_texts on p.TextID equals trans.TextID
                         join lang in _context.epc_languages on trans.LanguageID equals lang.LanguageID
                         select new
                         {
                             PartId = p.PartID,
                             Code = p.PartName,
                             Caption = trans.Caption,
                             LanguageId = lang.shortname.ToLower()
                         }).AsEnumerable().GroupBy(x => x.PartId).Select(g => new SearchPartModel
                         {
                             Code = g.Select(x => x.Code).FirstOrDefault(),
                             PartId = g.Key,
                             Name = g.Select(x => new
                             {
                                 x.LanguageId,
                                 x.Caption
                             }).Distinct().ToDictionary(y => y.LanguageId, y => y.Caption)
                         });
