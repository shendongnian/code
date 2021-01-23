    //start with the full set
    var results = DbSet<Foo>();
    //then build the where clause using conditional logic based on which checkboxes are checked
    if(aCheckBoxIsChecked)
    {
        results = results.Where(foo => foo.A == true); //each where you add is effectively an and
    }
    if(bCheckBoxIsChecked)
    {
        results = results.Where(foo => foo.B == true);
    }
    ... //and keep on with as many checkboxes as you have
    if(aCheckBoxIsChecked && cCheckBoxIsChecked)
    {
        results = results.Where(foo => foo.B != true);
    }
    else if(!aCheckBoxIsChecked)
    {
        results = results.Where(foo => foo.B == true || foo.C == true);
    }
    else if(...) //any other clauses
    {
        ... //any other logic
    }
    ... //any other tests
    /* The key insight, is that Linq will not execute your query until 
    you try to access the results. Therefore, you can continue to build
    an arbitrarily complex query until you've finished it, and then you
    can execute it, as in the below line. */
    return results.ToList(); //Execute. Or whatever method you want to use to execute the query.
