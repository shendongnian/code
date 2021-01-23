    public class Logged: IEquatable<Logged>, IComparable<Logged>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string OtherProperty { get; set; }
        public bool Equals(Logged other)
        {
            return this.Id == other.Id && this.UserName == other.UserName;
        }
        public int CompareTo(Logged other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
