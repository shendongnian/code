    public class Request {
        // Property
        public bool IsMailSent { get; private set; }
        public void MailSent() {
           // TODO check some conditions
           if (...) {
               ...
           }
           // If everything is correct set the property
           IsMailSent = true;
        }
    }
