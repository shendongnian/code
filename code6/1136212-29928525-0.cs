    class Father
    {
        int prop1;
        int prop2;
        // much more properties;
        protected Father(Father copy)
        {
            prop1 = copy.prop1;
            prop2 = copy.prop2;
        }
    }
    class Child : Father
    {
     string _name;
     int _age;
     //etc...
     public Child(string Name, int Age, Father father)
        : base(father)
     {
        this._name = Name;
        this._age = Age;
     }
    }
