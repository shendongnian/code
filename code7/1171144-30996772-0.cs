    public class TestTable
    {
        private string _new_name;
        private string _address;
        [Column(Storage = "_new_name", DbType = "nvarchar (2000)")]
        public string new_name {
            get
            {
                return _new_name;
            }
            set
            {
                _new_name = value;
            }
        }
        [Column(Storage = "_address", DbType = "nvarchar (5000)")]
        public string address {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
    }
