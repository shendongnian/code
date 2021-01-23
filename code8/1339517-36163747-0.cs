    switch (sortOrder)
    {
        case "date_desc":
            person.Sessions = person.Sessions
                                    .OrderByDescending(session => session.Training);
            break;
        default:
            person.Sessions = person.Sessions
                                    .OrderBy(session => session.Training);
            break;
                
    }
