    var a = Observable.Range(1, 10);
    var b = Observable.Range(10, 20);
    var merged = a.Select(i => new Container {id = "a", value = i})
                  .Merge( b.Select(i => new Container {id = "b", value = i}));
    var c = Observable.Return(true); 
    var result = merged.CombineLatest( c , (ab, selector ) 
                      => (selector && ab.id == "a") || (!selector && ab.id == "b") ? ab : null)
                       .Where(i => i != null);
    public class Container
    {
        public string id;
        public int value;
    }
