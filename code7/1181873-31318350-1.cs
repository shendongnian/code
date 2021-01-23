    public class Obj
    {
        public int health{ get; set; }
    }
    var o = new Obj();
    function changeHealth(Obj o)
    {
        o.health = 1;
    }
    print o.health; // show 1
