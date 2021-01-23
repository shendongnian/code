    public partial class MyEntity
    {
        public DateTime Date
        {
            get { return ConvertToDateTime(this.IntDate); }
        }
    }
