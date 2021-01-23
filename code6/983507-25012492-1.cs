    public class Util
    {
        public void Function(String s, Action<Status> setStatusListener)
        {
            // ....
            setStatusListener("myStatus");
        }
    }
    public class Activity
    {
        private Util util = new Util();
        public void AnotherFunction()
        {
            util.Function("name", status => LoginSetAvailabilityStatus(status));
        }
        
        public void LoginSetAvailabilityStatus(string status){
            //do something with status
        }
       
    }
