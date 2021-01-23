    var predicate = new StringBuilder();
    var parameters = new List<object>();
    
    for (int = 0; i < words.Length; i++) {
       if (i > 0) {
          predicate.Append(" OR ");
       }
       predicate.AppendFormat("({0} LIKE {{{1}}})", GetFieldName(i), i);
       parameters.Add(words[i]);
    }
    
    var query = SQL
        .FROM("myTable")
        .WHERE("(" + predicate.ToString() + ")", parameters.ToArray());
