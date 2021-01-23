            List<string> colours = new List<string>();
            colours.Add("black");
            colours.Add("red");
            var placeHolders = string.Join(",",(from colour in colours select "?").ToList());
            var sql = @String.Format(" SELECT * FROM Experience WHERE Colors IN ({0}); ",placeHolders);
            DataSet dsColors = new DataSet();
            using (OdbcConnection cn = new OdbcConnection(ConnectionString))
            {
                cn.Open();
                using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                {
                    foreach(var colour in colours)
                    {
                        cmd.Parameters.AddWithValue(colour, colour);
                    }
                    
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    adapter.Fill(dsColors);
                }
            }
