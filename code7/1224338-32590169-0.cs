    public class MyObject
    {
        public bool Foo { get; set; }
        public bool Bar { get; set; }
        public bool Meh { get; set; }
        public MyObject()
        {
        }
        public override bool Equals(object obj)
        {
            var item = obj as MyObject;
            if (item == null)
            {
                return false;
            }
            return (item.Foo == this.Foo && item.Bar == this.Bar && item.Meh == this.Meh);
        }
        public override int GetHashCode()
        {
            return new { Foo, Bar, Meh }.GetHashCode();
        }
    }
