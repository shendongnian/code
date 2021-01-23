    IQueriable<History> GetHistory(Events teamInEvent)
    {
        // Normal Query
        var firstQuery = 
        from h1 in History
        select h1 
        where h1.FirstTeam == teamInEvent.FirstTeam || 
              h1.SecondTeam == teamInEvent.SecondTeam;
   
        // Query with the first and the second team fields swapped
        var secondQuery = 
        from h2 in History
        select new History { Date = h2.Date, 
                             FirstTeam = h2.SecondTeam, 
                             FirstTeamGoals = h2.SecondTeamGoals, 
                             SecondTeam = h2.FirstTeam,
                             SecondTeamGoals = h2.FirstTeamGoals 
                           }
        where h2.FirstTeam == teamInEvent.SecondTeam || 
              h1.SecondTeam == teamInEvent.FirstTeam;
       // Stitch two queries together
       return firstQuery.Concat(secondQuery);
    }
