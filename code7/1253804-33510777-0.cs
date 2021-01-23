    private IEnumerable<SelectListItem> GetReportRunDates()
    {
      return RenewalUnderwritingLayer.GetReportRunDates().Select(r => new SelectListItem
      {
        Text = string.Format("{0:MM/dd/yyyy}", r.RunDate),
        Value = r.RunDate
      };
    }
