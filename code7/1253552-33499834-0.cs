      //_date is your date value and conS is your connection string
        public int InsertDate(DateTime _date, string conS) 
        {
              try
              {
                    using (var cn = new OleDbConnection(conS))
                    {
                          string queryString = "INSERT INTO... some_date_field=@dateparam"; //your query
                          var cmd = new OleDbCommand(queryString, cn);              
                          cmd.Parameters
                          .Add(new OleDbParameter("@dateparam", _date)); // add the parameter
                          cn.Open();
                          int res = cmd.ExecuteNonQuery();
                          return res;
                     }
             }
             catch
             {
                   return -2; // if you get that you will know something has gone wrong
             }
        }
