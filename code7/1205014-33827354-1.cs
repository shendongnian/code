    public class MigrationScriptBuilder : SqlServerMigrationSqlGenerator
    {
    #if !DEBUG
        protected override void Generate(SqlOperation sqlOperation)
        {
            Statement("GO");
            base.Generate(sqlOperation);
            Statement("GO");
        }
        
        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            yield return new MigrationStatement {Sql = "BEGIN TRAN"};
            foreach (var migrationStatement in base.Generate(migrationOperations, providerManifestToken))
            {
                yield return migrationStatement;
            }
            
            yield return new MigrationStatement {Sql = "COMMIT TRAN"};
        }
    #endif
    }
