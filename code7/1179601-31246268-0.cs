    public interface IReady
    {
        bool ready { get; set; }
    }
    public class Main : Monobehaviour, IReady {
        ...
        public bool bool ready { get; set; }
        ...
    }
      
      
    public class WaitAction {
                             
        public IEnumerator SomeCoroutine<T>(float count, T _ready) where T : IReady
        {
            ...
            _ready.Ready = true;
        }
    }
