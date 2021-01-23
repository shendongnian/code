    public class FirebirdSqlGenerator : FbMigrationSqlGenerator
    {
        protected override IEnumerable<MigrationStatement> Generate(AddForeignKeyOperation operation)
        {
            // Reduce the name using this method
            operation.Name = GenerateForeignKeyNameFromOperation(operation);
            
            using (var writer = SqlWriter())
            {
                writer.Write("ALTER TABLE ");
                writer.Write(Quote(CheckName(ExtractName(operation.DependentTable))));
                writer.Write(" ADD CONSTRAINT ");
                writer.Write(Quote(CheckName(CreateItemName(operation.Name))));
                writer.Write(" FOREIGN KEY (");
                WriteColumns(writer, operation.DependentColumns.Select(Quote));
                writer.Write(") REFERENCES ");
                writer.Write(Quote(CheckName(ExtractName(operation.PrincipalTable))));
                writer.Write(" (");
                WriteColumns(writer, operation.PrincipalColumns.Select(Quote));
                writer.Write(")");
                if (operation.CascadeDelete)
                {
                    writer.Write(" ON DELETE CASCADE");
                }
                yield return Statement(writer.ToString());
            }
        }
        public string GenerateForeignKeyNameFromOperation(AddForeignKeyOperation foreignKeyOperation)
        {
            var depTable = GetShortNameFromTableName(CreateItemName(foreignKeyOperation.DependentTable));
            foreignKeyOperation.Name = "FK_" +
                             depTable +
                             "_" +
                             GetShortNameFromTableName(CreateItemName(foreignKeyOperation.PrincipalTable)) +
                             "_" +
                             String.Join("_", foreignKeyOperation.DependentColumns);
            return foreignKeyOperation.Name;
        }
        [...]
    }
