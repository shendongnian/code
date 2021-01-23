    public class Party<T>
    {
        public T Find(int id)
        {
             ...
        }
    }
    
    public class Customer : Party<Customer>{}
    public class Company : Party<Company>{}
