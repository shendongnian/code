    public class Foo
    {
        var frobbed = false;
        public bool Frobbed { get { return frobbed; } }
        public void Frob() { frobbed = true; }
    }
    void Frob(Foo foo) { foo.Frob(); }
    var myFoo = new Foo();
    Frob(myFoo);
    Console.WriteLine(myFoo.Frobbed); //Outputs True! Why? Because myFoo and foo both point to the same object! The value of both variables (memory address) is the same!    
