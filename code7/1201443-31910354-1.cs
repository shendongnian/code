    public class ObjB : IOrderDate
    {
        public DateTime CreationDate { get; set; }
        public DateTime CreateDate
        {
            get { return CreationDate; }
        }
        public override string ToString()
        {
            return string.Format("CreationDate: {0}", CreationDate);
        }
    }
