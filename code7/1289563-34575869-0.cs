    public class ViewModel
    {
        private readonly ObservableCollection<string> _testListsName;
        public ObservableCollection<string> TestListsNames
        {
            get { return _testListsName; }
        }
        private void TestListNamesInitialize()
        {
            _testListName.Clear();
            _testListName.AddRange(db.GetTestListNamesFromDatabase());
        }
    }
