    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        // rest of properties and declarations
        //Class methods and constructors
        public override string ToString()
        {
            StringBuilder ObjectString = new StringBuilder();
            ObjectString.AppendLine("Stdent Details");
            ObjectString.AppendLine("Name :" + this.Name);
            ObjectString.AppendLine("ID :" + this.Id);
            ObjectString.AppendLine("Email :" + this.email);
            return ObjectString.ToString();
        }
    }
