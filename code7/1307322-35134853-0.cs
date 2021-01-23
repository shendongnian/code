    class SlaveObj()
    {
        MainObj _owner;
        readonly int _field1 = ...;
        readonly string _field2 = ...;
        // you need a way to set owner, e.g. constructor parameter
        public SlaveObj(MainObj owner)
        {
            _owner = owner; // good example why underscore in field name is good
        }
        // object type
        public object GetFieldX(MainObj asker) => askwer != _owner ? _field1 : _field2;
    }
    class MainObj()
    {
        List<SlaveObj> _slaves = new List<SlaveObj>();
        // return first slave field value
        // has nothing to do with instance, therefore static
        // will return null if no slave
        public static object GetFieldX(MainObj owner)
        {
            return owner?._slaves[0].GetFieldX(this);
        }
    }
