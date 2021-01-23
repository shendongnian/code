        private object readScalarFromDatabase(String query) //return object at first column and row
        {
            SqlCommand myCommand = new SqlCommand(query, Connection);
            return myCommand.ExecuteScalar();
        }
        public static string GetTotalLinksAlias(Parameter par)
        {
            return @"
                select count(1)
                from alias_parameter_parameter
                where id_parameter = " + par.Id + @"
                ;
            ";
        }
        public int GetTotalLinksParameterWithParameterAliases(Parameter par)
        {
            openConnection();
            int totalLinks = (int)readScalarFromDatabase(QueryGenerator.GetTotalLinksParameterAlias(par));
            closeConnection();
            return totalLinks;
        }
