    public interface IParserBehaviors {
        void StartNextComponent();
        void SetTableName(string tableName);
        void DefineColumns(IEnumerable<string> columnNames);
        void LoadNewDataRow(IEnumerable<object> rowValues);
        DataTable ProduceTableForCurrentComponent();
        // etc.
    }
