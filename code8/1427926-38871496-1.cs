    public class state_master: XYZ
    {
        private country_master CountryMaster;
        // Class constructor
        public state_master(country_master cm)
        {
            CountryMaster = cm;
        }
        private string _id;
        ...
