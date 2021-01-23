    public class Role
    {
        public static class Author
        {
            public static Role Seasoned {get;} = new Role(0, "Seasoned author");
            public static Role Elite {get;} = new Role(1, "Elite author");
        }
        public static class Editor
        {
            public static Role Approved {get;} = new Role(2, "Approved editor");
            public static Role Occassional {get;} = new Role(3, "Occassional editor");
        }
        public string Name { get; private set; }
        public int Value { get; private set; }
    
        private Role(int val, string name) 
        {
            Value = val;
            Name = name;
        }
    
        public IEnumerable<Role> List()
        {
            return new[]{Author.Seasoned,Author.Elite,Editor.Approved,Editor.Occassional};
        }
    
        public Role FromString(string roleString)
        {
            return List().FirstOrDefault(r => String.Equals(r.Name, roleString, StringComparison.OrdinalIgnoreCase));
        }
    
        public Role FromValue(int value)
        {
            return List().FirstOrDefault(r => r.Value == value);
        }
    }
