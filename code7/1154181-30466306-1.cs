    var csvFilteredRecord = Context.JT_Temp.GroupBy(k=> new
      {
        c.EnvelopeCode,
        c.Branch_COA,
        c.AQ_COA,
        c.AQ_Branch,
        c.AQ_PostStatus
      },
      v=>v.Amount,
      (k,v)=>new {
        k.EnvelopeCode,
        k.Branch_COA,
        k.AQ_COA,
        k.AQ_Branch,
        k.AQ_PostStatus
        Amount=v.Sum()
      });
    foreach (var Record in csvFilteredRecord)
    {
      Console.WriteLine(
        Record.EnvelopeCode
        + Record.Branch_COA
        + Record.AQ_COA
        + Record.Amount
        + Record.AQ_PostStatus
      );
    }
