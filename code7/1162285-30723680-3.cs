        string[] idArr = new string[TotalWinners];
        for (int i = 0; i < TotalWinners; i++)
        {
            idArr[i] = Winners[i, 0].ToString();
        }
        string idList = string.Join(",", idArr);
        DataSet dsWinners = new DataSet();
        dsWinners.Tables.Add(ds.Tables[0].Select("ID IN (" + idList + ")").CopyToDataTable());
