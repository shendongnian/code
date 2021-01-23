        public static List<string> GetSomething(string propName, Prize prize)
        {
            List<string> doubles = new List<string>();
    
            using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ForteLotteryDataConnectionString"].ConnectionString))
            {
                var query = string.Format(
                    @"SELECT Member.IBAN,
                        FROM Member, Summary,
                        WHERE Member.ID = Summary.{0},
                        AND PrizeID = {1}", propName, prize.ID
                );
    
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
    
                ...
    
                connection.Close();
            }
    
            return doubles;
        }
