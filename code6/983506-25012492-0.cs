    public class Util
    {
        public void function(String s, Action<Status> setStatusListener)
        {
            // ....
        }
    }
    public class Activity
    {
        public void anotherFunction()
        {
            util.function("name", status => loginSetAvailabilityStatus(status));
        }       
    }
