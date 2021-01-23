    public class AClass<T>
    {
        Action<T> _action;
        public AClass(Action<T> function) 
        {
            _action = function;
        }
        public void Exec(T parameter)
        {
            _action.Invoke(new object[] { parameter });
        }
    }
    private void MyMethod(int param)
    {
        // ....
    }
    AClass<int> myClass = new AClass<int>(MyMethod);
    myClass.Exec(10);
