    internal class Program {
        private static void Main(string[] args) {
            var c1 = new Element[] {
                new Element() {ID = "Category 1", Children = new Element[] {
                    new Element() {ID = "Child X" },
                    new Element() {ID = "Child Y" }
                }},
                new Element() {ID = "Category 2",}
            };
            var c2 = new Element[] {
                new Element() {ID = "Category 1", Children = new Element[] {
                    new Element() {ID = "Child X" },
                    new Element() {ID = "Child Z" }
                }},                
            };
            var keys = new HashSet<string>(GetFlatKeys(c2));
            var result = FindDiff(c1, keys).ToArray();
            Console.WriteLine(result);            
        }
        private static IEnumerable<Element> FindDiff(Element[] source, HashSet<string> keys, string key = null) {
            if (source == null)
                yield break;
            foreach (var parent in source) {
                key += "|" + parent.ID;
                parent.Children = FindDiff(parent.Children, keys, key).ToArray();
                if (!keys.Contains(key) || (parent.Children != null && parent.Children.Length > 0)) {                   
                    yield return parent;
                }
            }
        }
        private static IEnumerable<string> GetFlatKeys(IEnumerable<Element> source, string key = null) {
            if (source == null)
                yield break;
            foreach (var parent in source) {
                key += "|" + parent.ID;
                yield return key;
                foreach (var c in GetFlatKeys(parent.Children, key))
                    yield return c;
            }
        }
    }
