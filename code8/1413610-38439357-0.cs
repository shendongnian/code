    public class Foo : ArrayList, IDisposable
    {
       ...
    }
    public class Bar : IDisposable
    {
       ...
    }
    
    Random rand = new Random();
    public IDisposable SomtimesGetArrayList()
    {
        if(rand.Next(0,4) == 0)
            return new Bar();
        return new Foo();
    }
    
    //Elsewhere
    IDisposable foo = SomtimesGetArrayList();
    ArrayList bar = (ArrayList)foo;
