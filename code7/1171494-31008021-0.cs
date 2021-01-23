    var q = CommonFiltering(dataContext.sezione_a, aUserId, dataInizioControllo, dataFineControllo, a52Exclude)
      .Join(
            dataContext.sezione_d,
            a => new { A03 = a.A03, User = a.utente },
            d => new { A03 = d.A03, User = d.utente },
            (a, d) => new SezioneJoin { A = a, D = d }
          )
        .Where(x =>
          ...
        ).Take(Parameters.ROW_LIMIT);
    protected virtual IQueryable<AType> CommonFiltering(IQueryable<SezioneA> sj, int aUserId, DateTime? dataInizioControllo, DateTime? dataFineControllo, string[] a52Exclude)
    {
      sj = sj.Where(x => x.utente == aUserId);
      if (dataInizioControllo != null)
      {
        string dataInzio = dataInizioControllo.Value.ToString("yyyyMMdd");
        sj = sj.Where(x => x.A21.CompareTo(dataInzio) >= 0);
      }
      if (dataFineControllo != null)
      {
        string dataFine = dataFineControllo.Value.ToString("yyyyMMdd");
        sj = sj.Where(x => x.A21.CompareTo(dataFine) <= 0);
      }
      if (a52Exclude != null)
        sj = sj.Where(x => !a52Exclude.Contains(x.A52));
      return sj;
    }
