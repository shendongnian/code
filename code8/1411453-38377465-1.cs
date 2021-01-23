    public partial class CustomDataGrid : UserControl, INotifyPropertyChanged
    {
        public CustomDataGrid()
        {
            InitializeComponent();
            maingrid.DataContext = this;
        }
    
        public static readonly DependencyProperty NewItemsSourceProperty =
                   DependencyProperty.Register("NewItemsSource"
                       , typeof(IEnumerable)
                       , typeof(CustomDataGrid)
                       , new PropertyMetadata(null, OnItemSourcechanged));
    
    
    
        public IEnumerable NewItemsSource
        {
            get { return (IEnumerable)GetValue(NewItemsSourceProperty); }
            set
            {
                SetValue(NewItemsSourceProperty, value);
            }
        }
    
        public static readonly DependencyProperty CustomRowDetailsProperty =
                   DependencyProperty.Register("CustomRowDetails"
                       , typeof(string)
                       , typeof(CustomDataGrid));
    
        private static void OnItemSourcechanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CustomDataGrid).maingrid.ItemsSource = (IEnumerable)e.NewValue;
        }
    
        public string CustomRowDetails
        {
            get
            {
                return (string)GetValue(CustomRowDetailsProperty);
            }
            set {
                SetValue(CustomRowDetailsProperty, value);
            }
        }
    
        private object selItem;
    
        public object SelItem
        {
            get { return selItem; }
            set {
                selItem = value;
                MyDetails = (IEnumerable<object>)value.GetType().GetProperty(CustomRowDetails).GetValue(value, null); ;
                OnPropertyChanged(() => SelItem);
                OnPropertyChanged(() => MyDetails);
            }
        }
    
        private IEnumerable<object> myDetails;
    
        public IEnumerable<object> MyDetails
        {
            get { return myDetails; }
            set { myDetails = value;
                OnPropertyChanged(() => MyDetails);
            }
        }
    
    
    
        #region INotifyPropertyChanged Members
    
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
    
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
        {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            MemberExpression body = selectorExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The body must be a member expression");
            OnPropertyChanged(body.Member.Name);
        }
    
    
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            //this.VerifyPropertyName(propertyName);
    
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    
        #endregion // INotifyPropertyChanged Members
    
    }
