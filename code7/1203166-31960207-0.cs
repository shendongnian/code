    public class Recursively<T> {
        public T Instance { get; set; }
    }
    
    ...
    
    var recursively = new Recursively<Recursively<Recursively<string>>>();
    Console.WriteLine(recursively.Instance.GetType().ToString());
    Console.Writeline(recursively.Instance.Instance.GetType().ToString());
    Console.Writeline(recursively.Instance.Instance.Instance.GetType().ToString());
