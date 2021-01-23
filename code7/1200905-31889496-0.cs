    class CommonFunctions
    {
        public static void SetPropertyWithNotification<T>(ref T OriginalValue, T NewValue)
        {
            if (!OriginalValue.Equals(NewValue))
            {
                OriginalValue = NewValue;
                //Do stuff to notify property changed                
            }
        }
    }
    public class MyClass
    {
        private List<string> _strList = new List<string>();
        public List<string> StrList
        {
            get { return _strList; }
            set { CommonFunctions.SetPropertyWithNotification(ref _strList, value); }
        }
    }
