    public class Food : Object 
    {
        public void Eat() { }
    }
    public class OfficeMaterial : Object { }
    
    public class Contents : Object 
    {
        bool _visible = false;
        List<Object> _things = new List<Object>();
        public int Count { get { return _things.Count; } }
        public bool IsOpen { get { return _visible; } }
        public void Expose()
        {
            _visible = true;
        }
        public void Hide()
        {
            _visible = false;
        }
        public void Add(object thing)
        {
            _things.Add(thing);
        }
        public bool Remove(object thing)
        {
            return _things.Remove(thing);
        }
    }
    public class Box : OfficeMaterial 
    {
        public Contents BoxContents = new Contents();
    }
    public class Egg : Food 
    {
        public Contents EggContents = new Contents();
    }
