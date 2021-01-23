    foreach(DataRow row in dtTable.Rows)
    {
        var employee = row["tempEmployee"].ToString();
        var names = employee.Spit('/'); // solves issue 1
        foreach(var name in names)
        {
            var nameParts = name.Split(' ');
            string first = nameParts.TakeWhile(p => p != nameParts.Last()).Aggregate((a, b) => a + b);
            string last = nameParts.Last();
        }
    }
