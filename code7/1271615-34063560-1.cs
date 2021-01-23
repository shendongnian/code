     public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<String> Str { get; set; }
        public string Details<--------------------------------
        {
            get
            {
                String locStr=string.Empty;
                foreach (var item in this.Str)
                    locStr += item + ", ";
                return locStr;
            }
        }
    }
