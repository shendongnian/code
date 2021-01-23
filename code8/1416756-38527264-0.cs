    while (rdr.Read())
    {
        int index = this.chart1.Series["Month"].Points.AddXY(rdr["date"].ToString(),
                                         rdr.GetDouble("totalamt"));
        if (rdr.GetDouble("totalamt") < 5000) 
            this.chart1.Series["Month"].Points[index].Color = Color.Red;
    }
