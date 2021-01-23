    namespace NewtonExtensions
    {
        public static class Extensions
        {
            public static IEnumerable<JToken> AllChildren(this JToken json)
            {
                foreach (var c in json.Children())
                {
                    yield return c;
                    foreach (var cc in AllChildren(c))
                    {
                        yield return cc;
                    }
                }
            }
        }
    }
