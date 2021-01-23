            DataSet custom = new DataSet();
            DataTable Parameters = new DataTable("Parameters")
                .AddColumn<string>("Code")
                .AddColumn<int>("ID");
            Parameters.Columns["ID"].AutoIncrement = true;
            DataTable Expiries = new DataTable("Expiries")
                .AddColumn<int>("ID")
                .AddColumn<string>("Code")
                .AddColumn<string>("date")
                .AddColumn<string>("time")
                .AddColumn<string>("reason");
            custom.Tables.Add(Parameters);
            custom.Tables.Add(Expiries);
            custom.Relations.Add(new DataRelation("ParameterExpiries", Parameters.Columns["ID"], Expiries.Columns["ID"]));
            custom.Relations["ParameterExpiries"].Nested = true;
            Expiries.Columns["Code"].Expression = "Parent.Code";
