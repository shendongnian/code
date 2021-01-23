    public class Foo
    {
        private const int DefaultBar = 20;
        ///<summary>
        ///Does the thing.
        ///</summary>
        ///<param name="bar">Description of bar. Defaults to <see cref="DefaultBar"/>.</param>
        public int DoTheThing(int bar = DefaultBar)
        {
            return bar;
        }
    }
