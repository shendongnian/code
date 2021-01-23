    public class Migrations : DataMigrationImpl {
    
        public int Create() {
            
            SchemaBuilder.CreateTable(typeof(CyclePartRecord).Name, table => table
                // Unique identifier etc.
                .ContentPartRecord()
    
                .Column<DateTime>("Start")
                .Column<DateTime>("End"));
    
            return 1;
        }
    }
