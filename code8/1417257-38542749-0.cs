     var _FinalResult = from s in dbContext.tblSchedules
     group s by new
     {
         s.A,
         s.B,
         s.C,
         s.D,
     } into gt
     select new GrillTotals
     {
         SumOfA = gt.Sum(g => g.A ?? 0),
         SumOfB = gt.Sum(g => g.B ?? 0),
         SumOfC = gt.Sum(g => g.C ?? 0),
         CountOfD1 = gt.Count(g => g.D == "D1"),
         CountOfD2 = gt.Count(g => g.D == "D2"),
     };
