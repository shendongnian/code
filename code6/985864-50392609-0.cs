    // _context = instance of MyDbContext from ctor
    var lastAppliedMigration = _context.Database.GetAppliedMigrations().LastOrDefault();
    var lastDefinedMigration = _context.Database.GetMigrations().LastOrDefault();
    Console.WriteLine($"Last applied migration id: {lastAppliedMigration}");
    Console.WriteLine(lastAppliedMigration == lastDefinedMigration
        ? "Database is up to date."
        : $"There are outstanding migrations. Last defined migration is: {lastDefinedMigration}");
