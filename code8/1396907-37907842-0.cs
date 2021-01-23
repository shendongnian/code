        var parent = new Table2()
        {
            Table1Id = 1,
            SecondColumn = 1
        };
    
        parent.Tables3.Add(new Table3()
        {
            Table1Id = 1,
            SecondColumn = 1,
            AnotherColumn = 1
        });
    
        context.Set<Table2>().Add(parent);
        context.SaveChanges();
