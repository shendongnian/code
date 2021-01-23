        var connection_string = "some connection string";
        using (IDatabaseContext context = new DatabaseContext(connection_string))
        {
            IUnitOfWork unit_of_work = new UnitOfWork(context);
            ITestEntityReopsitory reopsitory = new TestEntityReopsitory(context);
            ITestEntityservice service = new TestEntityservice(unit_of_work, reopsitory);
            //Consume service here
            ....
        }
