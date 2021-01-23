    public class MyObject
    {
        public Int32 Id
        {
            get;
            set;
        }
        public Int32 OperationId
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("{0}-{1}", this.Id, this.OperationId);
        }
    }
