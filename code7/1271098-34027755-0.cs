     visits = visitJoins.AsEnumerable().Select(joined => new VisitPDV()
     {
         VisiteId = joined.Visite.VisiteId.ToString(),
         NomPointDeVente = (joined.VisitePdvProduit == null) ? null : joined.VisitePdvProduit.PointDeVente.NomPointDeVente,             
     });
