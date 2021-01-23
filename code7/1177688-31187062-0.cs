    // Get all possible migration classes (use base class + namespace)
    var dbMigrationClasses = migrationsAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(DbMigration)));
    var migrationNamespaceClasses = migrationsAssembly.GetTypes().Where(t => t.Namespace != null && t.Namespace.EndsWith(".Migrations", StringComparison.OrdinalIgnoreCase));
    
    // Join them together for tests to query
    migrationClasses = dbMigrationClasses.Union(migrationNamespaceClasses);
