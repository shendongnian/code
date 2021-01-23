    public class Foo
    {
        private readonly List<Bar> bars = new List<Bar>();
        public IEnumerable<Bar> Bars => bars.Select(b => b);
        public void AddBar(Bar bar)
        {
            bar.Foo = this;
            bars.Add(bar);
        }
    }
