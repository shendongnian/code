    public interface INavigation
    {
        // Property mapping field names to values
        public Dictionary<string,string> CurrentRecordFields;
    
        public void FirstRecord(void);
        // ... plus all the other navigation methods.
    }
