    for( int i = 1; i <= 200; i++ )
    {
        Thread.Sleep( 200 );
        using( var db = new MyDbContext( connectionString ) )
        {
            using( var trans = db.Database.BeginTransaction( IsolationLevel.Serializable ) )
            {
                db.Database.ExecuteSqlCommand(
                    "SELECT TOP 1 FROM Test WITH (TABLOCKX, HOLDLOCK)"
                );
                var entry = db.Tests.Find( 1 );
                db.Entry( entry ).Entity.Value += 1;
                // Just for testing
                Console.WriteLine( string.Format( "{0,5}", i ) + "   " + string.Format( "{0,7}", db.Entry( entry ).Entity.Value ) );
                db.SaveChanges();
                trans.Commit();
            }
        }
    }
