    public class UserContextWrapper : ICustomUserContext
    {
        public Guid UserGuid
        {
            get { return CustomerContext.Current.User; }
        }
    }
