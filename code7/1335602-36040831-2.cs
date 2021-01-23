    public class Definitions
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int smallId { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
        // DECLARE THE DICTIONARY AT CLASS LEVEL.
        private static Dictionary<string, int> _dict = new Dictionary<string, int>();
    
        // int idFromDatabase;
        // int smallIdFromDatabase;
        public static Dictionary<string, int> getDefinitions()
        {
            // RETURN DICTIONARY IF WE HAVE VALUE. DON'T NEED TO GET FILES!
            if (_dict.Count >= 0) return _dict;
            var files = (from name in Directory.EnumerateFiles(Folder)
                select new Definitions
                {
                    Name = Path.GetFileNameWithoutExtension(name),
                    Id = File.ReadLines(name).Skip(2).First()
                }).ToArray();
    
    
            //LOOP THROUGH DATABASE ++++++++++
            for (int i = 0; i < files.Length; i++)
            {
                if ((files[i].Id) == idFromDatabase)
                {
                    files[i].smallId = smallIdFromDatabase;
                }
                //LOOP THROUGH DATABASE ++++++++++
    
    
                //+++++++++++++ Dictionary CREATE++++++++++++++++        
    
                foreach (Definitions item in files)
                {
                    _dict.Add(item.Name, item.smallId);
                }
                //+++++++++++++ Dictionary CREATE++++++++++++++++   
                return _dict;
            }
        }
    
        public static int GetID(string word)
        {
            // ++++++Dictionary check +++++++
            int result;
            if (_dict.TryGetValue(word, out result))
            {
                return result;
            }
            return -1;
        }
    }
