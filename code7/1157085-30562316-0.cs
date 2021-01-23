    public static bool ContainsAny(string searchField, params string[] words) {
                foreach(string word in words) {
                    if(searchField.Contains(word))
                        return true;
                }
    
                return false;
            }
    
    
            public static void Main(string[] args){
                var list = new List<string>() { "test", "test2", "Sand", "Loam", "Clay" };
                var selectedList = from item in list where ContainsAny(item, "Sand", "Loam", "Clay")
                                   select item;
                foreach(var item in selectedList) {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
