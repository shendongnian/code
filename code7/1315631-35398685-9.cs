    public class Logged: IEquatable<Logged>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string OtherProperty { get; set; }
        public bool Equals(Logged other)
        {
            return this.Id == other.Id && this.UserName == other.UserName;
        }
    }
