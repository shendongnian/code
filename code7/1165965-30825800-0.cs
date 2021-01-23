        class Program
        {
            static void Main(string[] args)
            {
                var p = new Program();
                p.SampleFunc(Seasons.Winter, Seasons.Fall);
            }
            void SampleFunc<T>(params T[] elements)
            {
                foreach(var element in elements)
                {
                    if (element is Seasons)
                    {
                        // do something.
                    }
                }
            }
            enum Seasons
            {
                Winter, Spring, Summer, Fall
            }
        }
