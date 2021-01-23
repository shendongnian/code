    private DataPoint MapDataRowToDataPoint(DataRow row)
    {
      try{
        var point = new DataPoint();
        
        point.XValue = double.Parse(row["SeriesID"].ToString());
        point.YValues = new double[]{
            Convert.ToDateTime(row["Y1"].ToString()).ToOADate(), 
            Convert.ToDateTime(row["Y2"].ToString()).ToOADate()
        };
        point.AxisLabel = row["SeriesName"].ToString(); 
        point.Color = ColorTranslator.FromHtml("#" + row["Colour"].ToString());
        point.BorderWidth = 1;
        point.BorderColor = Color.Black;
        point.ToolTip = row["ToolTip"].ToString()
                        + ((!string.IsNullOrEmpty(row["ToolTip"].ToString()))?"\n":"")
                        + "Start Date Time: #VALY{"+toolTipDateTimeFormat+"}\n" 
                        +"End Date Time:   #VALY2{"+toolTipDateTimeFormat+"}";
        point.IsValueShownAsLabel = false;
        point.PostBackValue = row["PostBackValue"].ToString();
        
        return point;
      }
      catch
      {
        //Log the error
        return null;
      }
    }
