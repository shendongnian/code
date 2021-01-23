            //Config
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //initialize configuration, each line is responsible for telling entity framework how to create relation ships between the different tables in the database.
            //Such as Table Names, Foreign Key Contraints, Unique Contraints, all relations etc.
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new PersonEmailConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new LoginSessionConfig());
            modelBuilder.Configurations.Add(new AccountConfig());
            modelBuilder.Configurations.Add(new EmployeeConfig());
            modelBuilder.Configurations.Add(new ContactConfig());
            modelBuilder.Configurations.Add(new ConfigEntryCategoryConfig());
            modelBuilder.Configurations.Add(new ConfigEntryConfig());
            modelBuilder.Configurations.Add(new SecurityQuestionConfig());
            modelBuilder.Configurations.Add(new SecurityQuestionAnswerConfig());
