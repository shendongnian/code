    public class Person : INotifyPropertyChanged, IEditableObject
    {
        private bool isEditing;
        private bool isChanged;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        private string name;
        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }
        private int age;
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (isEditing)
            {
                isChanged = true;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region IEditableObject
        public void BeginEdit()
        {
            isEditing = true;
        }
        public void CancelEdit()
        {
            isEditing = false;
        }
        public void EndEdit()
        {
            if (isChanged)
            {
                // generate and execute update SQL here
            }
            isEditing = false;
        }
        #endregion
    }
