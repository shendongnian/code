    ProgramContext _dbContext = new ProgramContext();
        _dbContext.Programs.Add(new Program
        {
            SecondProgram = new SecondProgram
            {
                Title = "Demo"
            }
        });
        _dbContext.SaveChanges();
        var item = _dbContext.Programs.Find(1);
