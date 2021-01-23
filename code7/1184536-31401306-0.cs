    public interface ILoadable
    {
        void Load(DataRow row);
    }
    public class Person : ILoadable
    {
        ...
    
        public Person() { }
    
        public void Load(DataRow row)
        {
            PersonID = (int)row["person_id"];
            ...
        }
    }
