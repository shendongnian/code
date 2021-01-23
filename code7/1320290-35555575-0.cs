    public partial class MyEntity
    {
        public TimeSpan Duration
        {
            get
            {
                TimeSpan ts =(TimeSpan) (EndDateTime - StartDateTime);
                return ts;
            }
        }
    }
