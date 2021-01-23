    listaSolicitacao.GroupBy(s => new { s.CodigoOriginal, s.Data, s.ID })
       .Select(g => new SolicitacaoConhecimentoTransporte {
             ID = g.Key.ID,
             Data = g.Key.Data,
             CodigoOriginal = g.Key.CodigoOriginal,
             Caixas = g.SelectMany(s => s.Caixas).ToList()
        }).ToList()
