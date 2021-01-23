    public abstract class ErrorViewModel
    {
        public abstract int Id { get; }
    
        public abstract string Name { get; }
    }
    public class ElmahErrorViewModel
    {
        public ElmahErrorViewModel(ElmahError instance)
        {
            this.Instance = instance;
        }
        public ElmahError Instance { get; private set; }
        public int Id { get { return Instance.ErrorId; } }
    
        public string Name { get { return instance.Appication; } }
    }
