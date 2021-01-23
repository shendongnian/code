    var context = new DataClasses1DataContext();
    var sb = new StringWriter();
    context.Log = sb;
    var query = (from a in context.Persons select a.Name);
    string s = query.ToString();
    string command = context.GetCommand(query).CommandText;
    //The log requires the query to actually hit the database
    query.ToList();
    string log = sb.ToString();
