    var dit = new Dictionary<Pages, List<string>>()
                                  {
                                      { Pages.Search, SearchFilters.Id.ToMemberList() },
                                      { Pages.Report, ReportFilters.Age.ToMemberList() }
                                  };
        
    var x1 = dit[Pages.Search];
