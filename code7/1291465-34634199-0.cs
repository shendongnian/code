    public abstract class BaseClass
    { // all same attributes and methods
        public long GetPoint(int nationalCode);
        
        public async Task<long> GetPointAsync(int nationalCode)
        {
             return await GetPoint(nationalCode);
        }
    }
