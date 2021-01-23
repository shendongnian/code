                var results = (from d1 in t1().AsEnumerable()
                              join d2 in t2().AsEnumerable() 
                                    on d1.Field<string>("Enitity") equals d2.Field<string>("Enitity")
                              select new { Entity = d1.Field<string>("Enitity"), Variable = d1.Field<string>("Variable"), Variable2 = d2.Field<string>("Variable2") });
            DataTable myNewDataTable = results.CopyToDataTable<DataRow>();
