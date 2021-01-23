    class CachedDataReader
    {
         private readonly Lazy<YourLoadedData> data;
         public CachedDataReader(string filePath)
         {
             // Prepare loading logic, but don't do anything yet.
             data = new Lazy<YourLoadedData>(() => Load(filePath));
         }
         private YourLoadedData Load(string filePath) { } // Load your data here.
         public string GetValue(int param)
         {
             // Access data.Value here to read cached data.
             // The Load method will be called the first time only,
             // all subsequent calls will use the cached value.
         }
    }
