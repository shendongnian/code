        var playersOnTheTable = DataProvider.PlayersOnTheTable(okeyTableID).OrderBy(x => x.OkeyTablePlayerChairNumber).ToList();
    
        int yourSitPositionIndex = playersOnTheTable.FindIndex(x => x.UserID == userID);
    
        var beforePlayers = playersOnTheTable.GetRange(0, yourSitPositionIndex);
    
        IEnumerable<tbl_Okey_TablePlayer> afterPlayers = playersOnTheTable.Except(beforePlayers);
    
        IEnumerable<tbl_Okey_TablePlayer> newPositions = afterPlayers.Concat(beforePlayers);
