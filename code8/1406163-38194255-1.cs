    public static class Services
    {
        public static ILibraryService<T> GetLibraryService<T>() 
            where T : Library
        {
            return null; // ...
        }
    }
    
    public static class Services<T>
        where T : Library
    {
        public static ILibraryService<T> LibraryService { get; set; }
    }
    public static class Services<T>
        where T : ILibraryService<Library>
    {
        public static T LibraryService { get; set; }
    }
    public static class Services<TService, TLibrary>
        where TService : ILibraryService<TLibrary>
        where TLibrary : Library
    {
        public static ILibraryService<TLibrary> LibraryService { get; set; }
    }
