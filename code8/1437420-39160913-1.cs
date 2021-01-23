     var compare= tableold.AsEnumerable().Select(r => r.Field<int>("Dosage"))
             .Except(tableNew.AsEnumerable().Select(r => r.Field<int>("Dosage")));
     DataTable tblResult= (from row in tableold.AsEnumerable()
                                    join id in compare
                                    on row.Field<int>("Dosage") equals id
                                    select row).CopyToDataTable();
