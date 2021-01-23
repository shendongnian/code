    IList<Department> departments;
    var parents = new List<int> {167};
    // advantage of this "original" QueryOver is, that it can accept
    // more parent IDs.. not only one "100" as in our example
    // so if we neet children of 100,101,102
    // we can get more from this syntax: new List<int> {100, 101,102...};
    departments = session
        .QueryOver<Department>()
        .Where(Restrictions.On<Department>( x=> x.Parent.Id)
            .IsIn(parents))
        .List();
    // this style is just a bit more straightforward 
    // saving few chars of code, using 'WhereRestrictionOn'
    departments = session
        .QueryOver<Department>()
        .WhereRestrictionOn(x => x.Parent.Id).IsIn(parents)
        .List();
    // in case we do have the only one parent ID to search for
    // we do not have to use the IS IN
    departments = session
        .QueryOver<Department>()
        .Where(x => x.Parent.Id == 100)
        .List();
