    class Program
    {
        static void Main(string[] args)
        {
            ViewModel vm = new ViewModel()
            {
                DataAccess = new DataAccessFake()
            };
            string result = vm.Test("test"); //this returns "test_original"
        }
    }
    public class ViewModel
    {
        public DataAccess DataAccess { get; set; }
        public string Test(string key)
        {
            return DataAccess.Retrieve(key);
        }
    }
    public class DataAccess
    {
        public string Retrieve(string key)
        {
            return key + "_original";
        }
    }
    public class DataAccessFake : DataAccess
    {
        public new virtual string Retrieve(string key)
        {
            return key + "_fake";
        }
    }
