    public abstract class BaseInterimController : Controller {
        IInterimIdentityProvider identifier;
        public BaseInterimController(IInterimIdentityProvider identifier) {
            this.identifier = identifier;
        }
    
        protected string InterimName {
            get { return MultiInterim.GetInterimName(identifier.InterimIdentifier); }
        }
    
        //This can be refactored to the code above or use what you had before
        //internal virtual string InterimIdentifier {
        //    get { return identifier.InterimIdentifier; }
        //}
    }    
