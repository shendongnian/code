    public IHttpActionResult PostBanners(xx id)
            {
                string queryString = "select top 2 a.point,a.seq_banner  from Banners as a left join RelationCountryBanner as b on a.seq_banner = b.seq_file ";
               //string queryString = id.str;
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection())
                {
                    if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
                    {
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                    }
                    else
                    {
                        con.ConnectionString = "Data Source=******;Initial Catalog=B2CGlobal2010;Persist Security Info=True;User ID=*******;Password=****";
                    }
                    using (SqlCommand cmd = new SqlCommand(queryString.ToString(), con))
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
    
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
    
                        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                        Dictionary<string, object> row;
                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        DataTable xx = (DataTable)JsonConvert.DeserializeObject(serializer.Serialize(rows), (typeof(DataTable)));
                       // return Ok(xx);
                        return Ok(serializer.Serialize(rows));
                    }
                }
    
                return NotFound();
            }
