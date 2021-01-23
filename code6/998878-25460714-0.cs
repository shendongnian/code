    public interface IFileStorage 
    {
        Task SaveFileAsync(string filename, string contents);
        Task<String> LoadFileAsync(string filename); 
    } 
