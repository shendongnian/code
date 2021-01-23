    public class Obj
    {
        public DateTime Date { get; set; }
    }
    Obj o1 = new Obj { Date = DateTime.Now };
    Obj o2 = new Obj { Date = DateTime.Now };
    
    bool result = new Comparator<Obj>().Equals(o1, o2);
