    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e){
      if (e.Row.RowType == DataControlRowType.DataRow) {
        string Threshold = e.Row.Cells[3].Text.Replace("%", "").Trim();
     
        // Exact match
        if (e.Row.Cells[4].Text == Threshold)
          e.Row.Cells[4].BackColor = Color.MediumSeaGreen;
        else {  
          // no match: either threshold is exceeded or values are incomparable 
          int ThreCol;
          int ResCol;
    
          // Both values are integers and ResCol > ThreCol
          if (int.TryParse(e.Row.Cells[3].Text.Replace("%", ""), out ThreCol) &&
              int.TryParse(e.Row.Cells[4].Text.Replace("%", ""), out ResCol) &&
              ResCol > ThreCol)
            e.Row.Cells[4].BackColor = Color.Yellow;
          else
            e.Row.Cells[4].BackColor = Color.LightCoral;
        }
      ...
