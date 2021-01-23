    protected void btnTest_Click(object sender, EventArgs e) {
      DateTime limit = DateTime.Now.Date;  
    
      DateTime userInput = new DateTime(
        int.Parse(DDLYear.SelectedItem.Text),
        int.Parse(DDLMonth.SelectedItem.Text), 
        int.Parse(DDLDay.SelectedItem.Text));  
    
      //TODO: it's unclear from the question if you want ">" or ">=", put right comparison
      if (userInput >= limit)  {
        Response.Write("not valid day ");
    
        return;
      }
      ...
    }
