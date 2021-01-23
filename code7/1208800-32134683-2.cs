    class Customer
    {
        //...... your logic
        public static bool operator ==(Customer x, Customer y)
        {            
            return true; // add your logic for comparison here
        }
        public static bool operator !=(Customer x, Customer y)
        {
            return false; // add your logic for comparison here
        }
    }
