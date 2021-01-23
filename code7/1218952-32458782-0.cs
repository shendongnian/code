    public int Count {
        get {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return _count;
        }
        private set {
            Contract.Requires(value >= 0);
            _count = value;
        }
    }
