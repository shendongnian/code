            oleDA.Fill(Obj_Duration, Dts.Variables["User::Obj_Duration"].Value);
            foreach (DataColumn col in Obj_Duration.Columns)
            {
                Mail = Mail + "<th bgcolor='#7A378B' align='center'><font color='#FFFFFF'>" + col.ColumnName + "</font></th>";
            }
            foreach (DataRow row in Obj_Duration.Rows )
            {
                sMail = sMail + "<tr>";
                foreach (DataColumn col in Obj_Duration.Columns)
                {
                    sMail = sMail + "<td align = 'center'>" + row[col.Ordinal].ToString() + "</td>";
                }
                sMail = sMail + "</tr>";
                Mail = Mail + sMail;
                sMail = "";
                Mail = Mail + "<br>";
                int i = Obj_Duration.Rows.IndexOf(row);
                if (AlternatingDataTableName.Rows.Count - 1 >= i)
                {
                    DataRow alternatingRow = AlternatingDataTableName.Rows[i];
                       //Start TR
                    foreach (DataColumn col in AlternatingDataTableName.Columns )
                    {
                        //Start TD
                         //alternatingRow[col.Ordinal].ToString()
                        //End TD
                    }
                    // end TR
                }
            }
            sMail = "";
            Mail = Mail + "</table>";
            Mail = Mail + "<br>";
        }
