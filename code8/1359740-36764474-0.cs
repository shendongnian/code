    [MetadataType(typeof(ClientMetadata))]
    [CustomValidation(typeof(ClientValidator), "ClientValidation")]
    public partial class Client : INotifyDataErrorInfo
    {
        private Dictionary<string, ICollection<string>> validationErrors = new Dictionary<string, ICollection<string>>();
        public sealed class ClientMetadata
        {
            [Display(ResourceType = typeof(CaptionResources), Name = "Name")]
            public string Name { get; set; }
        }
        public Dictionary<string, ICollection<string>> ValidationErrors
        {
            get
            {
                return this.validationErrors;
            }
            set
            {
                this.validationErrors = value;
            }
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !this.ValidationErrors.ContainsKey(propertyName))
            {
                return null;
            }
            return this.ValidationErrors[propertyName];
        }
        public bool HasErrors
        {
            get { return this.ValidationErrors.Count > 0; }
        }
        public void RaiseErrorsChanged(string propertyName)
        {
            if (this.ErrorsChanged != null)
            {
                this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
