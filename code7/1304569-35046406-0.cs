    public void FillDates(int NumDaysBack)
    {
        for (DateTime d = DateTime.Now.AddDays(-NumDaysBack); d < DateTime.Now; d = d.AddDays(1))
        {
            ddMiscDateList.Items.Add(d.ToShortDateString());
        }
        ddMiscDateList.Items.Add("Other");
    }
