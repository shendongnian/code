    Panela panela = null;
    Local local = null;
    
    var query = session.QueryOver<PanelaCorrida>()
        .JoinAlias(c => c.Panela, () => panela)
        .Where (c => c.Id.IsIn(corridaPanelaIdList.ToArray()))
        .SelectList(list => list
        .Select(c => c.Id))
        .Select(c => c.CodCorrida)
        .Select(Projections.Property(() => panela.Id).As("Panela.Id"))
        .Select(Projections.Property(() => panela.IdcAtiva).As("Panela.IdcAtiva"))
        .TransformUsing(Transformers.AliasToBean(typeof(PanelaCorrida)));
    
