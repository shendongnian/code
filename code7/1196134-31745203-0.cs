                DataTable dtYear = new DataTable(); 
                int Year1 = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                //add columns to DataTable
                dtYear.Columns.Add("Years",typeof(string), null);
                
                for (int i = 1980; i <= Year1; i++) 
                {
                    dtYear.Rows.Add(i);
                } 
        
               ddlYear.DataSource = dtYear;
               ddlYear.DataBind();
