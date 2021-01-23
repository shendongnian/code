    var select = something == otherthing ? 
        dbContext.tbl_person.Select(item => new PersonGridRow
        {
            PersonID = item.PersonID,
            ...
        }) :
        dbContext.tbl_personHistory.Select(item => new PersonGridRow
        {
            PersonID = item.PersonID,
            ...
        });
