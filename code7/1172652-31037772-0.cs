    var builder = SQL
        .SELECT("*")
        .FROM("myTable")
        .WHERE();
    
    foreach (var field in fields) {
            builder.WHERE("").Append("(")
            var index = 0;
            foreach (var value in field.values) {
                builder.AppendClause("WHERE", index == 0 ? "": " OR ", field.columnName + " LIKE {0}", new object[] { "%" + value.Value + "%" });
            }
            index++;
            builder.Append(")");
        }
