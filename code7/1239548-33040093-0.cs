      public List<List<string>>> Query_McAfeeConsolidation()
      {
          List<List<string>> li = Genkai_db.Consolidation_McAfee
                                           .Select(x => new List<string> { x.computername, "McAfee" })
                                           .ToList();
          return li;
      }
