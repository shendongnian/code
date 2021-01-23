    public class MyClass
    {
        int _myInt;
        
        virtual public int MyProperty
        {
            get
            {
                return _myInt;
            }
            set
            {
                _myInt = value;
            }
        }
    }
