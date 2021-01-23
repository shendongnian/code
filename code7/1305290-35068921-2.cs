    var pathToExcel = @"C:\temp\file.xlsx";
            var sheetName = "sheetOne";
            //This connection string works if you have Office 2007+ installed and your 
            //data is saved in a .xlsx file
            var connectionString = String.Format(@"
                Provider=Microsoft.ACE.OLEDB.12.0;
                Data Source={0};
                Extended Properties=""Excel 12.0 Xml;HDR=YES""
            ", pathToExcel);
            //Creating and opening a data connection to the Excel sheet 
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(
                    @"SELECT * FROM [{0}$]",
                    sheetName
                    );
                using (var rdr = cmd.ExecuteReader())
                {
                    //LINQ query - when executed will create anonymous objects for each row
                    var query =
                        (from DbDataRecord row in rdr
                        select row).Select(x => 
                        {
                            dynamic item = new ExpandoObject();
                            item.Add(rdr.GetName(0), x[0]);
                            item.Add(rdr.GetName(1), x[1]);
                            item.Add(rdr.GetName(2), x[2]);
                            return item;
                        });
                    //Generates JSON from the LINQ query
                    var json = JsonConvert.SerializeObject(query);
                    return json;
                }
            }
