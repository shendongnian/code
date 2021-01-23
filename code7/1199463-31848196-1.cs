    public static List<string> GetDoubles(Prize prize)
        {
            List<string> doubles = new List<string>();
    
            using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ForteLotteryDataConnectionString"].ConnectionString))
            {
                var query = string.Concat(
                    @"
                        SELECT Member.IBAN ",
                        "FROM Member, Summary ",
                        "WHERE Member.ID = Summary.DoubleID ",
                        "AND PrizeID = " + prize.ID
                );
    
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
    
                ...
    
                connection.Close();
            }
    
            return doubles;
        }
