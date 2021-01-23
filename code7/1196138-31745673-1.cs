     DataTable dtYear = new DataTable();
     dtYear.Columns.Add("year",typeof(int)); // add the column
     int Year1 = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
     for (int i = 1980; i <= Year1; i++)
     {
         dtYear.Rows.Add(i);
     }
     ddlYear.DataSource = dtYear;
     ddlYear.DataBind();
