    Table1.Where(t => t.UserId = userId)
          .OrderBy(t => t.CustomerName)
          .GroupBy(t => new {t.Customer_Num, t.Customer_Name})
          .Select(grp => new
          {
              grp.Key.Customer_Num,
              grp.Key.Customer_Name,
              Count = grp.Count(),
              State1Count = grp.Where(t => t.State = "State1").Count(),
              State2Count = grp.Where(t => t.State = "State2").Count(),
              USD_TOTAL_MRC_AMT_SUM = grp.Sum(t => t.USD_TOTAL_MRC_AMT_SUM) ?? 0
          })
          .Distinct();
