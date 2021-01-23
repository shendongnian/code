    var results = new List<DateAmountList>();
    using (var statement = this.connection.Prepare(
        "SELECT Date, SUM(Amount) FROM incomeamounts GROUP BY Date"))
    {
        while (statement.Step() == SQLiteResult.ROW)
        {
            var dateAmount = new DateAmountList
            {
                Date = DateFromInternalValue(statement[0]),     // This depends on what format you use to store your date
                Amount = (long)statement[1],                    // Could also be: Amount = statement.GetInteger(1),
            };
            results.Add(dateAmount);
        }
    }
