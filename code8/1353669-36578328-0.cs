    public class SFDC_Lease
    {
        public static string LastPropertySetted;
        public string LeaseNumber
        {
            get;
            set
            {
               LastPropertySetted = "LeaseNumber";
               LeaseNumber = value;
            }
        }
    }
