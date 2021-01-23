    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    
    namespace NewtonExtensions
    {
        public static class Extensions
        {
            private static IEnumerable<JToken> AllChildren(JToken json)
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
