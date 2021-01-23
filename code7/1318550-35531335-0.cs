    var sqlParams = list<SqlParameter>();
    int index = 0;
    foreach (var id in idNumbersInts)
       sqlParams.Add(new SqlParameter("@p" + (index++), id));
    string sqlQuery = String.Format(@"SELECT Make, Model
        FROM PHONES WHERE ID_NUM IN ({0})",
        String.Join(",", sqlParams.Select(p => p.ParameterName).ToArray()));
    var phones = _context.Database.SqlQuery<Phones>(sqlQuery,
        sqlParams.ToArray()).ToList();
