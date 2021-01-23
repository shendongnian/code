    (...)
        if (BeginInclusive)
        {
            var greaterOrEqual =
                Expression.Lambda<Func<T, bool>>(
                    Expression.GreaterThanOrEqual(
                        dateField.Body,
                        Expression.Constant(BeginDate)),
                    dateField.Parameters);
    
            result = result.Where(greaterOrEqual);
        }
    (...)
