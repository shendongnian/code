    public class Party<T>
    {
        public static T Find(int id)
        {
             ...
        }
    }
    
    public class Customer : Party<Customer>{}
    public class Company : Party<Company>{}
