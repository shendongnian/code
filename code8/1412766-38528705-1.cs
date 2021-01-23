    public class Obj
    {
        public double Double { get; set; }
    }
    Obj o1 = new Obj { Double = 22222222222222.22222222222 };
    Obj o2 = new Obj { Double = 22222222222222.22222222221 };
    bool result = new Comparator<Obj>().Equals(o1, o2);
