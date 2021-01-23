    void timer_Tick(object sender, EventArgs e)
    {
        foreach( DataRow row in YourDataTable.Rows)
        {
            var diff = row.Field<DateTime>("DateTimeColumn").Subtract(DateTime.Now);
            if(diff.TotalSeconds>0)
            {
                row["DurationColumn"] = string.Format("{0} d {1:D2}:{2:D2}:{3:D2}", 
                                           diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
            }
            else
            {
                row["DurationColumn"] = "0 d 00:00:00";
            }
        }
    }
