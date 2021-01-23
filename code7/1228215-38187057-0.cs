    public interface IInterimIdentityProvider {
           string InterimIdentifier { get; }
    }
    public class ConcreteInterimIdentityProvider : IInterimIdentityProvider {
        public virtual string InterimIdentifier {
            get { return System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["InterimIdentifier"].ToString(); }
        }
    }
