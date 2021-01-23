    orgData = (from d in db.tbl_FormsSubmittedValues
               where d.SiteID == _siteID
               & d.FormID == _formID
               & ((d.tbl_FormsSubmitted.UserID == _userID && _viewOwnOnly) || !_viewOwnOnly)
               & ((_search != "" && d.Value.Contains(_search)) || _search == "")
               select new {
                           d.FormSubmissionID,
                           Value = d.ValueDate.HasValue ? d.ValueDate.Value: d.ValueLong != null ? d.ValueLong : d.Value,
                           d.FieldID,
                           d.FormID,
                           d.SiteID,
                           d.tbl_FormsSubmitted,
                           d.tbl_FormsSubmitted.UserID
                          }).AsEnumerable() //Using this to get the query to run.
               //Anything after this should not be done on the database side.
               .Select(d => new
               {
                   d.FormSubmissionID,
                   Value = d.ValueDate.HasValue ? FormatDate(d.ValueDate.Value): d.ValueLong != null ? d.ValueLong : d.Value,
                   d.FieldID,
                   d.FormID,
                   d.SiteID,
                   d.tbl_FormsSubmitted,
                   d.tbl_FormsSubmitted.UserID,
               }).ToList();
    static string FormatDate(DateTime date)
    {
        return  date.Value.ToShortDateString();
    }
