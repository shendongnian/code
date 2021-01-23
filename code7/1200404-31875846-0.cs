    partial class MyEntity
    {
        DateTime Date
        {
            get { return ConvertToDateTime(this.IntDate); }
        }
    }
