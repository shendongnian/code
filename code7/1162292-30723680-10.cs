        Dictionary<string, string> winnersList = new Dictionary<string, string>();
        for (int i = 0; i < TotalWinners; i++)
        {
            winnersList.Add(Winners[i, 0], Winners[i, 1]);
        }
        string idList = string.Join("','", winnersList.Select(x => x.Key));
        DataSet dsWinners = new DataSet();
        dsWinners.Tables.Add(ds.Tables[0].Select("ID IN ('" + idList + "')").CopyToDataTable());
        dsWinners.Tables[0].Columns.Add("prize_amt", typeof(string));
        dsWinners.Tables[0].Rows.OfType<DataRow>().ToList().ForEach(x =>
        {
            x["prize_amt"] = winnersList[x["ID"].ToString()];
        });
        dsWinners.Tables[0].AcceptChanges();
