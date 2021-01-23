    internal class Data { /* whatever */ }
    internal static class DataLoader
    {
        private static Task<Data> loaderTask;
        public static Task<Data> LoadDataAsync(bool refresh = false)
        {
            if (refresh || loaderTask == null)
            {
                loaderTask = LoadDataCoreAsync();
            }
            return loaderTask;
        }
        private static async Task<Data> LoadDataCoreAsync()
        {
            // your actual logic goes here
        }
    }
