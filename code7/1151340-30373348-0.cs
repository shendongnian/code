    public class SaveMongo : IEquatable<SaveMongo>
    {
        public ObjectId _id { get; set; }
        public DateTime date { get; set; }
        public Guid ClientId { get; set; }
        public List<TypeOfSave> ListType = new List<TypeOfSave>();
        public List<ObjectId> ListObjSave = new List<ObjectId>();
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SaveMongo) obj);
        }
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
        public bool Equals(SaveMongo other)
        {
            return _id.Equals(other._id);
        }
    }
