    public class Program
    {
        private static IEnumerable<Bar> Find( Foo foo, String name )
        {
            foreach ( var x in foo.Bars.Where( x => x.Name == name ) )
                yield return x;
            
            var bars = foo.Foos?.SelectMany( x => Find( x, name ) ) ?? new Bar[0];
            foreach ( var y in  bars)
                yield return y;
        }
        public static void Main( String[] args )
        {
            var foo = new Foo
            {
                Bars = new List<Bar>
                {
                    new Bar { Name = "n1" },
                    new Bar { Name = "n2" },
                    new Bar { Name = "n3" },
                    new Bar { Name = "n4" }
                },
                Foos = new List<Foo>
                {
                    new Foo
                    {
                        Bars = new List<Bar>
                        {
                            new Bar { Name = "n1" },
                            new Bar { Name = "n2" },
                            new Bar { Name = "n3" },
                            new Bar { Name = "n4" }
                        },
                        Foos = new List<Foo>
                        {
                            new Foo
                            {
                                Bars = new List<Bar>
                                {
                                    new Bar { Name = "n1" },
                                    new Bar { Name = "n2" },
                                    new Bar { Name = "n3" },
                                    new Bar { Name = "n4" }
                                }
                            }
                        }
                    },
                    new Foo
                    {
                        Bars = new List<Bar>
                        {
                            new Bar { Name = "n1" },
                            new Bar { Name = "n2" },
                            new Bar { Name = "n3" },
                            new Bar { Name = "n4" }
                        }
                    }
                }
            };
            foreach ( var x in Find( foo, "n1" ) )
                Console.WriteLine( x.Name );
            Console.ReadLine();
        }
    }
    public class Foo
    {
        #region Properties
        public IEnumerable<Foo> Foos { get; set; }
        public IEnumerable<Bar> Bars { get; set; }
        #endregion
    }
    public class Bar
    {
        #region Properties
        public String Name { get; set; }
        #endregion
    }
