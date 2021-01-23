    public class catData : ISelectable
    {
        public string catName;
        public string modGUID;
        public string versionLocal;
        public string versionServer;
        public bool onServer;
    
        /// <summary>
        /// Gets a name to display in the application to end-users.
        /// </summary>
        public string DisplayName {  get { return catName; } }
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
