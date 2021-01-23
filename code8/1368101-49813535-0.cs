    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                                optionsBuilder.UseSqlServer(DbConnectionString);
                                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                                {
                                    
                                    //save or update() on *context* here
                                }
