    public static List<string> GetWinners(Prize prize)
    {
        List<string> winners = new List<string>();
    
        using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ForteLotteryDataConnectionString"].ConnectionString))
        {
            var query = string.Concat(
                @"
                    SELECT Member.IBAN ",
                    "FROM Member, Summary ",
                    "WHERE Member.ID = Summary.WinnerID ",
                    "AND PrizeID = " + prize.ID
            );
    
            connection.Open();
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();
    
            ...
    
            connection.Close();
        }
    
        return winners;
    }
