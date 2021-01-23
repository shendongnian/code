    var Variances = words.AsParallel().Select((word) => {
         List<wordConfig> configlist = new List<wordConfig>();
         foreach (VariancePopulationConfig value in values) {
             VariancePopulationConfig config = new VariancePopulationConfig(Named, Category, Schedule);
             using (SqlConnection con = new SqlConnection(ConnectionString)) {
                 con.Open();
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = con;
                 cmd.Parameters.AddWithValue("@word", word);
                 cmd.Connection = con;
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = value.SelectQuery;
                 returnedvalue = cmd.ExecuteScalar().ToString();
                 config.DestinationColOrdinal = value.DestinationColOrdinal;
                 config.CurrentOrHistory = value.CurrentOrHistory;
                 config.WordValue = returnedvalue.Equals("0") ? string.Empty : returnedvalue;
                 config.Word = word;
             }
             configlist.Add(config);
         }
         return new Variance { Word = word, VarianceConfigs = configlist };
    }).ToList();
