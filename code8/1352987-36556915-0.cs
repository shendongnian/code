    public abstract class BaseParent<T> : Parent<T>, Parent
    {
        public abstract void DoSomething(T myObj);
        public void DoSomething(object myObj)
        {
            T obj = myObj as T;
            if (obj != null)
            {
                DoSomething(obj);
                return;
            }
            // Do something to handle null values, unexpected values
        }
    }
