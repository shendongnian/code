    public class LoggingMigrationDecorator : Migration {
            private Migration _migrationClass;
            public DateTime StartTime { get; private set; }
                
            public LoggingMigrationDecorator (Migration toDecorate)
                    {
                         _migrationClass = toDecorate;
                        this.StartTime = DateTime.Now;
                        Console.WriteLine("Start {0} - TIME: {1:yyyy-MM-dd HH:mm:ss.fff}", this.GetType().Name, StartTime);
                    }
                
                    public override void Up()
                    {
                     toDecorate.Up();
                     stopTimerFunction(); // your function that will stop timer and do something with result
        
                    }
                
                  
        
          public override void Down()
                {
                }
            }
        }
