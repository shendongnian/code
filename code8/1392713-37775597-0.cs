    public class Student
    {
        public string Key { get { return KeyQualifier + Id.ToString().PadLeft(4, '0'); } }
        public string KeyQualifier { get; set; } = "ST";
        public int Id { get; set; } //The Identity in the database
        public string First_Name { get; set; }
    }
