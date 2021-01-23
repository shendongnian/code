    public class EvilGraph
    {
        public EvilGraph(int V)
        {
            //...
        }
        public EvilGraph(TextReader inpt)
            : this(new Func<int>(() =>
            {
                inpt.ReadLine();
                return int.Parse(inpt.ReadLine());
            })())
        {
            //...
        }
    }
