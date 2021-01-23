    var itens = db.CREDITO
                .Join(db.BENEFICIARIO, cr => cr.CDBENEFICIARIO, bn => bn.CDBENEFICIARIO,
                                    (cr, bn) => new { cr, bn })
                .GroupBy(x => new { 
                                      x.cr.SITUACAODIVIDA, 
                                      x.bn.DEUF, 
                                      x.bn.DESUPERINTENDENCIAREGIONAL 
                                  }
                 )
                .Select(g => new { 
                                     DEUF = g.Key.DEUF,
                                     SITUACAODIVIDA = g.Key.SITUACAODIVIDA,
                                     VLTOTAL = g.Sum(z => z.cr.VLEFETIVAMENTELIBERADO),
                                     Count = g.Count()
                                 }
                       ).ToList();
