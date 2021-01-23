    public class SecondEntity : Cacheable<SecondEntity> { ... }
    var list = new List<ICacheable>();
    list.Add(new MyEntity());
    var something = new SecondEntity();
    // oops - runtime error
    list[0].CloneTo(something);    
 
