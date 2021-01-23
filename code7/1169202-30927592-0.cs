    public class BaseModel<T> // T will be your derived type
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
    
        public void Save()
        {
            // T will be your derived type now
            using(var repository = new Repository<T>()) {
                repository.Save(this);
            }
        }
    }
    
    // BaseModel will get the derived type as type parameter
    public class DerivedModel : BaseModel<DerivedModel>
    {
        public string Name { get; set; }
    }
