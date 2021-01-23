    namespace MyProgram.Migrations
    {
        using System;
        using System.Data.Entity;
        using System.Data.Entity.Migrations;
        using System.Linq;
        using System.Reflection;
        using MyProgram;
    
        internal sealed class MyConfiguration : DbMigrationsConfiguration<MyProgram.MyDbContext>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
    
                // This is the assembly where your real migration are (Your DbContext not for test!)
                MigrationsAssembly = Assembly.GetExecutingAssembly();
                MigrationsNamespace = "AssemblyNamespace.Migrations";
            }
        }
    }
