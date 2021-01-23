    public class Foo 
    {
        public Action Install {get; set; }
    }
    var x = new Foo();
    x.Install = () => { 
        // Whatever logic you'd like
    };
