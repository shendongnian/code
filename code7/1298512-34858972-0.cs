    class Customer : ICustomer
    {
        private string firstName;
        private string name;
        private string secondName;
        private string sName;
        private int iD;
        private int mId;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }
        public string SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }
        public int ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
            }
        }
        public int MId
        {
            get
            {
                return mId;
            }
            set
            {
                mId = value;
            }
        }
        public void SetName(string fName, string sName)
        {
            FirstName = fName;
            SecondName = sName ;
        }
    }
