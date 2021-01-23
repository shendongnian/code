            DataTable myNewDataTable = new DataTable();
            myNewDataTable.Columns.Add("Enitity", typeof(string));
            myNewDataTable.Columns.Add("Variable", typeof(string));
            myNewDataTable.Columns.Add("Variable2", typeof(string));
            var results = (from d1 in t1().AsEnumerable()
                           join d2 in t2().AsEnumerable()
                                 on d1.Field<string>("Enitity") equals d2.Field<string>("Enitity")
                           select myNewDataTable.LoadDataRow( new object[] { d1.Field<string>("Enitity"), d1.Field<string>("Variable"), d2.Field<string>("Variable2") }, true) );
            myNewDataTable = results.CopyToDataTable<DataRow>();
