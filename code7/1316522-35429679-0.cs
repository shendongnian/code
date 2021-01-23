    public specificguy(string name) : base(name)
    {
        // The line where you did "this._name = name;" need to be removed,
        // because "base(name)" does it for you now.
        this._job = "unemployed";
        this._address = "somewhere over the rainbow";
        // init also the parent parameters, like age and phone
    }
