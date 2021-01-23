    public abstract class BaseEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
		#region Methods
        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        public void OnPropertyChanged(string propertyName)
        {
            var ev = PropertyChanged;
            if (ev != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
         
        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="expr">Lambda expression that identifies the updated property</param>
        public void OnPropertyChanged<TProp>(Expression<Func<BaseEntity, TProp>> expr) 
        {
            var prop = (MemberExpression)expr.Body;
            OnPropertyChanged(prop.Member.Name);
        }
	}
    public class MyData : BaseEntity 
    {
        private string firstName;
    
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(e => e.FirstName); }
        }
    
        private string surName;
        public string Surname
        {
            get { return surName; }
            set { surName = value; OnPropertyChanged(e => e.Surname); }
        }
     }
