      public class UserViewModel:INotifyPropertyChanged
     {
        private string name;
        private string age;
        private string rule;
        private List<string> ruleType;
        public String Name 
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        public String Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged("Age"); }
        }
        public String Rule 
        {
            get { return rule; }
            set { rule = value; NotifyPropertyChanged("Rule"); }
        }
        public List<string> RuleType
        {
            get { return ruleType; }
            set { ruleType = value; NotifyPropertyChanged("RuleType"); }
        }
        public UserViewModel() 
        {
            name = "name";
            age = "";
            ruleType = new List<string>();
        }
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
     }
    }
       
