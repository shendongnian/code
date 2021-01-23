    public class state_master: XYZ
    {
        private country_master CountryMaster;
        // Class constructor
        public state_master()
        {
            CountryMaster = new country_master();
        }
        private string _id;
        ...
