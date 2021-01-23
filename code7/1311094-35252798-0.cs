    // Check if the subject name is already in the db.
    var subjects = db.Subject.Where(s => s.SubjectName.Equals(model.sub.SubjectName, StringComparison.CurrentCultureIgnoreCase));
    // If the name is in the table, do not add the name of the Id again.
    if (subjects.Any())
    {
        return;
    }
    var subjectId = subjects.First().Id;
    model.rev.SubjectId = subjectId;
    model.rgrade.SubjectId = subjectId;
    if (model.rev.GBU == "Good")
    {
         model.rgrade.Good = += 1;
    }
    else if (model.rev.GBU == "Bad")
    {
        model.rgrade.bad = += 1;
    }
    else if (model.rev.GBU == "Ugly")
    {
        model.rgrade.Ugly += 1;
    }
    // Save the entity (no need to set the state).
