    string strValues = "Location='Chemmad' and  Marks='100'"; // this is bad and will cause sql injection attacks.
    // what you actually want is an object(s) that you can use in the parameterized query. depending on your input you then dynamically create the where part of your string. something like this:
    var parameterValues = new
    {
    	Location = "Chemmad",
    	Marks = 100
    };
    
    const string searchTerm = " where ";
    var query = @"select * from Employee where Location=?Location and Age=?Age and Marks=?Marks";
    var part1 = query.Substring(0, query.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase));
    // the following line is not necessary and won't be used. It just illustrates how to get the remainder of the query.
    var part2 = query.Substring(query.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) + searchTerm.Length, query.Length - part1.Length - searchTerm.Length);
    
    var myDynamicQuery = part1 + searchTerm;
    myDynamicQuery = myDynamicQuery + "Location = :location ";
    myDynamicQuery = myDynamicQuery + "AND Marks = :marks ";
