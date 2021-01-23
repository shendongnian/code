    private IEnumerable<dynamic> _listOne;
    public IEnumerable<dynamic> ListOne {
        get {
            if (_listOne == null) {
                // Retrieve the data here. Of course you can just call a method of a
                // more complex logic that you have implemented somewhere else here.
                _listOne = ThirdParty.ListOne ?? Enumerable.Empty<dynamic>();
            }
            return _listOne;
        }
    }
