    public class DataRepositoryBase<T> : IDataRepository<T> {
        readonly EFContextProvider<User> _contextProvider =
            new EFContextProvider<User>();
    
        public void SaveEntity(JObject saveBundle) {
           _contextProvider.SaveChanges(saveBundle);
        }
    }
