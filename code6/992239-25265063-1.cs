    public class EzOleDbToFilePackage : EzSrcDestPackage<EzOleDbSource, EzSqlOleDbCM, EzFlatFileDestination, EzFlatFileCM>
    {
        public EzOleDbToFilePackage(Package p) : base(p) { }
        public static implicit operator EzOleDbToFilePackage(Package p) { return new EzOleDbToFilePackage(p); }
        public EzOleDbToFilePackage(string srv, string db, string table, string file)
            : base()
        {
            SrcConn.SetConnectionString(srv, db);
            Source.Table = table;
            DestConn.ConnectionString = file;
            Dest.Overwrite = true;
            // This method defines the columns in FlatFile connection manager which have the same
            // datatypes as flat file destination
            Dest.DefineColumnsInCM();
        }
        [STAThread]
        static void Main(string[] args)
        {
            // DEMO 2
            EzOleDbToFilePackage p2 = new EzOleDbToFilePackage("localhost", "AdventureWorks", "Address", "result.txt");
            p2.DataFlow.Disable = true;
            p2.Execute();
            Console.Write(string.Format("Package2 executed with result {0}\n", p2.ExecutionResult));
        }
    }
