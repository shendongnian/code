    return expression.InnerJoin(
        DbExpressionBuilder.Scan(joinEntity),
            (l, r) => DbExpressionBuilder.And(
                    DbExpressionBuilder.Equal(
                        DbExpressionBuilder.Property(l, "JoinId"),
                        DbExpressionBuilder.Property(r, "JoinId")
                    )
                )
            )
        .Select(exp => exp.Property("l"));
