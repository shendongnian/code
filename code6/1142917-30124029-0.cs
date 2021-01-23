    var b = _bookService.GetBooks();
    foreach (PropertyInfo p in typeof(Library).GetProperties())
    {
        // skip "books" property
        if (p.Name == "books")
        {
            continue;
        }
        // skip null values from lib
        if (p.GetValue(lib) == null)
        {
            continue;
        }
        // build condition dynamically
        var value = Expression.Constant(p.GetValue(lib));
        var param = Expression.Parameter(typeof (Books));
        var predicate = Expression.Lambda<Func<Books, bool>>(
            Expression.Equal(
                Expression.Property(param, p.Name), 
                value
            ),
            param
        );
        b = b.Where(predicate);
    }
