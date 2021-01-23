            var con = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='c:\\path to your xlsx';Extended Properties='Excel 12.0 Xml;HDR=YES'");
            string stbQuery = "SELECT * FROM [Sheet$]";
            OleDbDataAdapter adp = new OleDbDataAdapter(stbQuery, con);
            DataSet dsXLS = new DataSet();
            adp.Fill(dsXLS);
            var groups = dsXLS.Tables[0].Rows.OfType<DataRow>().GroupBy(r => r.ItemArray[0]);
            System.Data.DataTable t = new System.Data.DataTable();
            t.Columns.Add("Key");
            t.Columns.Add("Value");
            foreach (var grp in groups)
            {
                t.Rows.Add(grp.Key, grp.ToList().Select(r => r.ItemArray[1]).Aggregate((a, b) => a + "," + b));
            }
            Console.ReadLine();
