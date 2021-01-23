     public void FillChartReciversByLocations()
            {
                DataTable dt = new DataTable();
                BL.recivers rec= new BL.recivers();
                dt = rec.ReciversByLocations();
                chart1.Series.Clear();
                chart1.DataSource = dt;
                string SeriesName = dt.Rows[0]["location_name"].ToString();
                chart1.Series.Add(SeriesName);
                chart1.Series[SeriesName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Series[SeriesName].XValueMember = "location_name";
               chart1.Series[SeriesName].YValueMembers = "reccount";
                            
    
            }
