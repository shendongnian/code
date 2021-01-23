    var userPrize = (
        from a in tblUserprize
        join b in tblPrizeDetails on a.PrizeId equals b.PrizeId
        join c in tblWinnersList on new { a.EventID, a.PrizeId } equals new { c.EventID, c.PrizeId } into joinedTables
        from item in joinedTables.DefaultIfEmpty()
        where a.EventID == 1320 && item.FightID == 1534
        select new
        {
            a.EventID,
            a.PrizeId,
            b.PrizeName,
            b.PrizeValue,
            item.FightID,
            item.Winnerid,
            item.WinnerName
        });
