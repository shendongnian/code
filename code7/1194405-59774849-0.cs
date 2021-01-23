    public bool IsFooAFoo(string foo, string bar)
    {
        var aVeryLongAndComplexQuery = $@"SELECT yada, yada
        -- long query in here
        WHERE fooColumn = @{nameof(foo)}
        AND barColumn = @{nameof(bar)}
        -- long query here";
        SqlParameter[] parameters = {
            new SqlParameter(nameof(foo), SqlDBType.VarChar, 10){ Value = foo },
            new SqlParameter(nameof(bar), SqlDBType.VarChar, 10){ Value = bar },
        }
    }
