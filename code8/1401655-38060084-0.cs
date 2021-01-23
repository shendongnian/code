    Use this query.
        
    (from p in db.VW_PROJETOS
      join ic in db.vw_InstanciaCarteira
      on p.CodigoProjeto equals ic.CodigoProjeto
      where ic.CodigoCarteira == 125
      orderby p.CodigoProjeto
      select  new {
      CodigoProjeto=p.CodigoProjeto,
      NomeProjeto=p. NomeProjeto,
      Desempenho=ic.Desempenho
      }.ToList();
