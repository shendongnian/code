    public class MyClass
    {
        private readonly IRepo _repo;
        
        //or if you want a parameterless constructor...
        public MyClass() : this(new Repo()) { }      
        public MyClass(IRepo repo)
        {
            _repo = repo;
        }
    
        public MyObject MyMethod(int id)
        {
            _repo.GetById(id);
        }
    }
    public interface IRepo
    {
        MyObject GetById(int id);
    }
    public class Repo : IRepo
    {
        public MyObject GetById(int id)
        {
            using ( var db = new DbContext())
            {
                //do your db related stuff here
             }
        }
    }
