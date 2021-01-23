    namespace MyApp
    {
        interface IEntry
        {
            // Read only interface of Entry
        }
        
        class Entry : IEntry
        {
            // Concrete mutable class
        }
        
        class Program
        {
            private List<List<Entry>> _matrix;
            public List<List<IEntry>> matrixWithROElements => _matrix;
            public IReadOnlyList<List<IEntry>> matrixWithRONumberOfRows => _matrix;
            public List<IReadOnlyList<IEntry>> matrixWithRONumberOfColumns => _matrix;
            public IReadOnlyList<IReadOnlyList<IEntry>> matrixWithRONumberOfRowsAndColumns => _matrix;
        }
    }
