    DataRow[] rows = new DataRow[]{tRow1, tRow2.....};//im not sure how you refferenced them;
    void btnAdd_Click(object sender, EventArgs e)
    {
      foreach(DataRow dr in rows)
      {
         if(!dr.Visible)
         {
            dr.Visible = true;
            return;
         }
      }
    }
    void btnAdd_Click(object sender, EventArgs e)
    {
      foreach(DataRow dr in rows.Reverse())
      {
         if(dr.Visible)
         {
            dr.Visible = false;
            return;
         }
      }
    }
