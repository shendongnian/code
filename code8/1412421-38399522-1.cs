    // You forgot to access ".Status" in your code.
    // Also you don't have to use "=>" to initialize "IsVisible". Use the regular "=".
    public static Expression<Func<SubTable2, bool>> IsVisible = sub2 =>
        sub2.Status == "Visible";
    ...
    VisibleDivisions = sub1
        .SubTable2
        // Don't call "Compile()" on your predicate expression. EF will do that.
        .Where(IsVisibleOnly)
        .Select(sub2 => new 
            { 
                /* select only what needed */   
            })
