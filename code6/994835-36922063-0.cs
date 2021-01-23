    public class Teacher
    {   //...
        public string PaternalName { get; set; }
        public string MaternalName { get; set; }
        public string Name { get; set; }
        //... your others columns.  Add something like:
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}, {2}", PaternalName, MaternalName, Name);
            }
        }
        ...
    }
