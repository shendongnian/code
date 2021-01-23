    public ActionResult Index(int? page, [...parameters...], string caseStatus = "In Progress", Func<string> dropDownIssBy = null, string SortBy = "Issue Date asc")
    {
        if(dropDownIssBy == null)
        {
            dropDownIssBy = UName;
        }
    }
