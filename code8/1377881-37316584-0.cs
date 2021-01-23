    private ObservableCollection<string> _myEnumList;
    public ObservableCollection<string> MyEnumList
    {
        get
        {
            if (this._myEnumList == null)
            {
                string[] myList = Enum.GetNames(typeof(MyEnum));
                // You can also use your own logic to generate your list
                this._myEnumList = new ObservableCollection<string>(myList);
            }
            return this._myEnumList;
        }
    }
