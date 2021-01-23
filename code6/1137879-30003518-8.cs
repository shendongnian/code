    public class VariableDataItem  : IAmIAuthorized
    {
        public string Name { get; set; }
    
        public SecurityLevels Level { get; set; }
    
        public Func<IAmIAuthorized, bool> DetermineAuthorizationFunc { get; set; }
    
        public bool IsAuthorized
        {
            get { return DetermineAuthorizationFunc != null && 
                         DetermineAuthorizationFunc(this); }
        }
    
        public Visibility IsVisible
        {
            get { return IsAuthorized ? Visibility.Visible : Visibility.Hidden; }
        }    
    }
