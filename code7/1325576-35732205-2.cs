    using System.Collections.Generic;
    namespace MyApp
    {
        interface IEntry
        {
        }
        
        class Entry : IEntry
        {
        }
        
        class Program
        {
            private List<List<Entry>> _matrix = null;
            public List<List<IEntry>> MatrixWithROElements
            {
                get 
                {
                    return _matrix.ConvertAll(row => row.ConvertAll(item => item as IEntry));
                }
            }
            public IReadOnlyList<List<IEntry>> MatrixWithRONumberOfRows
            {
                get 
                {
                    return _matrix.ConvertAll(row => row.ConvertAll(item => item as IEntry));
                }
            }
            public List<IReadOnlyList<IEntry>> MatrixWithRONumberOfColumns
            {
                get 
                {
                    return _matrix.ConvertAll(row => row.ConvertAll(item => item as IEntry) as IReadOnlyList<IEntry>);
                }
            }
            public IReadOnlyList<IReadOnlyList<IEntry>> MatrixWithRONumberOfRowsAndColumns
            {
                get 
                {
                    return _matrix.ConvertAll(row => row.ConvertAll(item => item as IEntry));
                }
            }
            public void Main(string[] args)
            {    
            }
        }
    }
