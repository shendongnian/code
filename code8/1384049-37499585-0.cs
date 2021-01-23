    public class SomeModel {}
    public interface ISomeModelRepositoryService
    {
        SomeModel GetById(int id);
        void Save(SomeModel model);
    }
