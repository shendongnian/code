    public class MyClass
    {
        public void WorkWith<T>(Action<T> method) where T : MyClass
        {
            method.Invoke((T)this);
        }
    }
