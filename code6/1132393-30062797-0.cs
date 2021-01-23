                DataTable dt = this.data_allDataSet.merchandise;
            //use LINQ method syntax to pull the Title field from a DT into a string array...
            string[] postSource = dt
                                .AsEnumerable()
                                .Select<System.Data.DataRow, String>(x => x.Field<String>("name"))
                                .ToArray();
            var source = new AutoCompleteStringCollection();
            source.AddRange(postSource);
            cat_name.AutoCompleteCustomSource = source;
            cat_name.AutoCompleteMode = AutoCompleteMode.Suggest;
            cat_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
