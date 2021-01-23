    public class AClass<T>
    {
        private Action<T> _action;
        public AClass(Action<T> function) 
        {
            _action = function;
        }
        public void Exec(T parameter)
        {
            _action(parameter);
        }
    }
---
    private void MyMethod(int param)
    {
        // ....
    }
    var myClass = new AClass<int>(MyMethod);
    myClass.Exec(10);
