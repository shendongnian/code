    public ActionResult Index()
    {
        ViewBag.NominationStatuses = GetStatusSelectListForProcessView(status)
    }
    private SelectList GetStatusSelectListForProcessView(string status)
    {
        var statuses = new List<NominationStatus>(); //NominationStatus is Enum
        statuses.Add(NominationStatus.NotQualified);
        statuses.Add(NominationStatus.Sanitized);
        statuses.Add(NominationStatus.Eligible);
        statuses.Add(NominationStatus.Awarded);
        var statusesSelectList = statuses
               .Select(s => new SelectListItem
               {
                   Value = s.ToString(),
                   Text = s.ToString()
               });
        return new SelectList(statusesSelectList, "Value", "Text", status);
    }
