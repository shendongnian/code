    public partial class customers
    {
        public enum CustomerStatusEnum : long
        {
            Closed = 3,
            Open = 1,
            Potential = 2
        }
        public CustomerStatusEnum CustomerStatus
        {
            get
            {
                return (CustomerStatusEnum)Status;
            }
        }
    } 
