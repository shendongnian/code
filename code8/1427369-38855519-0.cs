                con.Open();
                string query1 = "SELECT type,name,value FROM " + server + " WHERE type LIKE '%port1'" ;                                      
                SqlCommand cmmd = new SqlCommand(query1, con);              
                SqlDataReader dataReader = cmmd.ExecuteReader();
                while (dataReader.Read())
                   {
                    chart1.Series.Add(dataReader["name"].ToString());
                    chart1.Series[dataReader["name"].ToString()].ChartType = SeriesChartType.StackedColumn;
                    chart1.Series[dataReader["name"].ToString()]["StackedGroupName"] = "Group1";                
                    chart1.Series[dataReader["name"].ToString()].Points.AddXY((dataReader["type"].ToString()), dataReader["value"].ToString());                    
                   }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
             }
            try
            {
                con.Open();
                string query2 = "SELECT type,name,value FROM " + server + " WHERE type LIKE '%port2'";
                SqlCommand cmmd2 = new SqlCommand(query2, con);
                SqlDataReader dataReader2 = cmmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                  
                    chart1.Series.Add(dataReader2["name"].ToString());
                   
                    chart1.Series[dataReader2["name"].ToString()].ChartType = SeriesChartType.StackedColumn;
                    chart1.Series[dataReader2["name"].ToString()]["StackedGroupName"] = "Group2";
                    // MessageBox.Show(dataReader2["type"].ToString());
                   chart1.DataBind();
                    chart1.Series[dataReader2["name"].ToString()].Points.AddXY("Port_2", dataReader2["value"].ToString());
                    chart1.Series[dataReader2["name"].ToString()]["PointWidth"] = "1";
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ ex);
            }
