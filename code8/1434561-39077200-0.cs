            DataSet ds = new DataSet();
            string s = Server.MapPath("test.xml"); // test.xml is your xml file
            ds.ReadXml(s);
            DataTable oldTable = ds.Tables[0];
            DataTable newTable = new DataTable();           
            newTable.Columns.Add("Page");
            for (int i = 0; i < oldTable.Rows.Count; i++)
                newTable.Columns.Add("# Of Hits");
            for (int i = 0; i < oldTable.Columns.Count; i++)
            {
                DataRow newRow = newTable.NewRow();
                newRow[0] = oldTable.Columns[i].Caption.Replace("Hits","");
                for (int j = 0; j < oldTable.Rows.Count; j++)
                    newRow[j + 1] = oldTable.Rows[j][i];
                newTable.Rows.Add(newRow);
            }
           // set newTable as datasource to grid view.
