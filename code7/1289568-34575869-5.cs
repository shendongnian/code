    public class ViewModel
    {
        private readonly ObservableCollection<string> _testListsName;
        public ObservableCollection<string> TestListsNames
        {
            get { return _testListsName; }
        }
        private void TestListNamesInitialize()
        {
            _testListsName.Clear();
            foreach(string name in db.GetTestListNamesFromDatabase())
            {
                _testListsName.Add(name);
            }
            
            if (_testListsNames.Count != 0) CanLoad = true;
        }
    }
