    var idFromSession = string.empty;
    if (Session["tchID"] != null)
    {
        idFromSession = Session["tchID"].ToString();
    }
    var filterdSubjects = db.Subjects.Where(s=>s.tchID == idFromSession);
    // Use filterdSubjects  to build your dropdown.
