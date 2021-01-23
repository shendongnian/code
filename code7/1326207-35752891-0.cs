    abstract class NetworkDevice
    {
        public void Flush() {
            // Logic
        }
        public void PowerDown() {
            // Logic
        }
    }
    public class Router : NetworkDevice
    {
        // New stuff, ignoring the one below
        public new void Flush() { 
            // new magic
        }
        public void Routaree() {
            // router specific magic
        }
    }
    public class Switch : NetworkDevice
    {
        public void Switcharoo() {
            // Switch centric stuff
        }        
    }
