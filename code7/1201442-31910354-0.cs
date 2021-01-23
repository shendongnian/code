    public class ObjA : IOrderDate
    {
        public DateTime DateOfCreation { get; set; }
        public DateTime CreateDate
        {
            get { return DateOfCreation; }
        }
        public override string ToString()
        {
            return string.Format("DateOfCreation: {0}", DateOfCreation);
        }
    }
