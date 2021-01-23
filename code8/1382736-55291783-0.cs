    private TimeSheetEntities db = new TimeSheetEntities();
    private void button1_Click(object sender, EventArgs e)
    {
      var recs = db.usp_ADMIN_SelectExistingSites();
      dgExistingSites.AutoGenerateColumns = false;
      dgExistingSites.DataSource = recs.ToList();
    }
