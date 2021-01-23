     public class Pony : IDataErrorInfo, INotifyPropertyChanged {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
    
        [Range(0,4)]
        public int Id {
          get; set;
        }
        [Required]
        public string Name {
          get; set;
        }
        public Brush Color {
          get; set;
        }
    
        public string Error {
          get {
            var builder = new StringBuilder();
            foreach (var error in this.Errors) {
              if (error.Value.Count > 0) {
                foreach (var text in error.Value) {
                  builder.AppendLine(text);
                }
              }
            }
            return builder.Length > 0 ? builder.ToString(0, builder.Length - 2) : builder.ToString();
          }
        }
    
        public bool HasError => this.Errors.Count > 0;
    
        public virtual string this[string columnName] {
          get {
            var modelClassProperties = TypeDescriptor.GetProperties(this.GetType());
            foreach (PropertyDescriptor prop in modelClassProperties) {
              if (prop.Name != columnName) {
                continue;
              }
              this.Errors[columnName] = new List<string>();
              foreach (var attribute in prop.Attributes) {
                if (!(attribute is ValidationAttribute)) {
                  continue;
                }
                var validation = attribute as ValidationAttribute;
                if (validation.IsValid(prop.GetValue(this))) {
                  continue;
                }
                var dn = prop.Name;
                foreach (var pa in prop.Attributes.OfType<DisplayNameAttribute>()) {
                  dn = pa.DisplayName;
                }
                this.Errors[columnName].Add(validation.FormatErrorMessage(dn));
                this.OnPropertyChanged("Error");
                return validation.FormatErrorMessage(dn);
              }
            }
            this.Errors.Remove(columnName);
            this.OnPropertyChanged("Error");
            return null;
          }
        }
    
        internal Dictionary<string, List<string>> Errors => this._errors;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
