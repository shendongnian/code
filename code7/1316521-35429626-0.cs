    public class specificguy:genericguy
    {
        private string _job;
        private string _address;
        //call the base class constructor by using : base()
        public specificguy(string name):base(name) //initializes name,age,phone
        {
            //need not initialize name as it will be initialized in parent
            //this._name = name;
            this._job = "unemployed";
            this._address = "somewhere over the rainbow";
        }
    }
