    SqlDataReader rdr = mobjGenlib.objDBLib.ExecuteQueryReader(sql.ToString());
            while (rdr.Read())
            {
                LocationName.Add(rdr.GetValue(0).ToString());
            }
            rdr.Close();
            repeaterSearchResult.DataSource = LocationName;
            repeaterSearchResult.DataBind();
