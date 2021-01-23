    var objStatDate =
        (from dt in _objContext.tbl_Project_Status_MSTR
        where dt.ProjectID.Equals(strprojectId)
        orderby dt.ProjectID
        select new {dt.StatusDate})
        .ToList() //Execute database query
        .Select(x =>
            new SelectListItem
            {
                Text = Convert.ToString(x.StatusDate), //Convert data in memory
                Value = Convert.ToString(x.StatusDate)
            })
        .ToList();
