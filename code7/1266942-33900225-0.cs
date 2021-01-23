    protected void ddlSelectWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime theDate;
        DateTime.TryParseExact(this.ddlSelectWeek.SelectedValue, "yyyy-MM-dd", CultureInfo.InvarientCulture, DateTimeStyles.None, out theDate);
        BindGridview(theDate);
    }
    protected void BindGridview(DateTime theDate)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[8] {
        new DataColumn("Category"),
        new DataColumn("Day1"),
        new DataColumn("Day2"),
        new DataColumn("Day3"),
        new DataColumn("Day4"),
        new DataColumn("Day5"),
        new DataColumn("Day6"),
        new DataColumn("Day7")
        });
        //add your category
        dt.Rows.Add("Travelling");
        dt.Rows.Add("Food");
        dt.Rows.Add("Air Fare,");
        dt.Rows.Add("Auto Rental");
    
        gvCategory.DataSource = dt;
        gvCategory.DataBind();
        //for generating datewise coloumn
        for (int i = 1; i < gvCategory.HeaderRow.Cells.Count; i++)
        {
            gvCategory.HeaderRow.Cells[i].Text = theDate.AddDays(i - 1).ToString("ddd") + " " + theDate.AddDays(i - 1).ToShortDateString();
        }
    }
