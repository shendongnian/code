    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e){
      if (e.Row.RowType == DataControlRowType.DataRow) {
        string Threshold = e.Row.Cells[3].Text.Replace("%", "").Trim();
    
        if (e.Row.Cells[4].Text == Threshold)
          e.Row.Cells[4].BackColor = Color.MediumSeaGreen;
        else {  
          int ThreCol;
          int ResCol;
    
          // Both values are integers and ResCol > ThreCol
          if (int.TryParse(e.Row.Cells[3].Text, out ThreCol) &&
              int.TryParse(e.Row.Cells[4].Text, out ResCol) &&
              ResCol > ThreCol)
            e.Row.Cells[4].BackColor = Color.Yellow;
          else
            e.Row.Cells[4].BackColor = Color.LightCoral;
        }
      ...
