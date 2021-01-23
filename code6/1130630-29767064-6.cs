    string code = "A-B-C-D-";
    var predicates = new List<Expression<Func<Customer,bool>>>();
    for (int i = 0; i < code.Length; i++)
    {
        if (code[i] == '-')
        {
            var prefix = code.Substring(0, i + 1);
            predicates.Add(x => x.EmployeeCode.StartsWith(prefix));
        }
    }
    var oredPredicates = ...; // Keep reading!
    ...
    var result = db.Employee.Where(oredPredicate);
