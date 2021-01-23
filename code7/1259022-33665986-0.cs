    using(var conn = new OleDbConnection(connString))
    using(var cmd = conn.CreateCommand())
    {
          cmd.CommandText = @"SELECT PreFix, Stem, PostFix FROM UrduStemmerTbl WHERE word = ?";
          cmd.Parameters.Add("?", OleDbType.VarWChar).Value = InputWord;
          // I assume your column type
          conn.Open();
          using(var dr = cmd.ExecuteReader())
          {
               if(dr.Read())
               {
                  prefixOutput.Text = dr.GetString(0);
                  stemOutput.Text = dr.GetString(1);
                  postfixOutput.Text = dr.GetString(2);
               }
          }
    }
