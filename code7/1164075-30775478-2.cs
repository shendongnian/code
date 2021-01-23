        public abstract class Social { public Guid uuid { get; private set; } }    
        public class Linkedin : Social{/*...*/}
        public class Twitter : Social{/*...*/}    
        public class Facebook : Social{/*...*/}
        
        public enum SocialNetworks
        {
            Linkedin,
            Facebook,
            Twitter
        }
