    double average; 
    
    foreach (DataRow row in dt.Rows)
    {
        average = row["AVG"];
    
        Chart1.Series[0].Points.AddXY(row["CUSTOMER"], new object[] { row["MIN"], row["MAX"],
        row["25TH_PERCENTILE"], row["75TH_PERCENTILE"], average, row["50TH_PERCENTILE"] });
    
        Chart1.Series[1].Points.AddXY(row["CUSTOMER"], new object[] { average }); 
    
        if(average >= 1 && average <= 5)
        {             
            Chart1.Series[1].MarkerColor = Color.Blue;
        }
        elseif(average >=6 && average <= 10)
        {
            Chart1.Series[1].MarkerColor = Color.Yellow;
        }
        else
        {
            Chart1.Series[1].MarkerColor=Color.Green;
        }
    }
