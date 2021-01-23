        List<Winners> winnersList = new List<Winners>();
        for (int i = 0; i < TotalWinners; i++)
        {
            Winners winner = new Winners();
            winner.ID = Winners[i, 0];
            winner.PrizeAmount = Convert.ToDecimal(Winners[i, 1]);
            winnersList.Add(winner);
        }
        string idList = string.Join("','", winnersList.Select(x => x.ID));
        DataSet dsWinners = new DataSet();
        dsWinners.Tables.Add(ds.Tables[0].Select("ID IN ('" + idList + "')").CopyToDataTable());
        dsWinners.Tables[0].Columns.Add("prize_amt", typeof(decimal));
        dsWinners.Tables[0].Rows.OfType<DataRow>().ToList().ForEach(x =>
        {
            x["prize_amt"] = winnersList.Find(y => y.ID == x["ID"].ToString()).PrizeAmount;
        });
