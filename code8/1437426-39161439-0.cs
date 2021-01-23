    DuplicateExpression.ForEach(n=>
        {
            bool IsContainColumn = itemProperties.Any(column => column.Name == n.ExpressionName);
            if (!IsContainColumn)
            {
                TempDuplicateExpression.Add(n);
            }
        }
    )
