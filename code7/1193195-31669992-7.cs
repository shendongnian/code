    public class CyclePartHandler : ContentHandler {
        public CyclePartHandler(IRepository<CyclePartRecord> repository) {
            // Enable storing the cyclepartrecord data
            Filters.Add(new StorageFilter.For(repository));
        }
    }
