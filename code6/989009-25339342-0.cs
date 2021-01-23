            DataSet custom = new DataSet();
            DataTable Parameters = new DataTable("Parameters")
                .AddColumn<string>("Code");
            DataTable Expiries = new DataTable("Expiries")
                .AddColumn<string>("Code")
                .AddColumn<string>("date")
                .AddColumn<string>("time")
                .AddColumn<string>("reason");
            custom.Tables.Add(Parameters);
            custom.Tables.Add(Expiries);
            custom.Relations.Add(new DataRelation("ParameterExpiries", Parameters.Columns["Code"], Expiries.Columns["Code"]));
            custom.Relations["ParameterExpiries"].Nested = true;
