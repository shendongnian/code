    public class MyArray<T>
    {
        private T[] _array;
        
        public MyArray()
        {
            // execute your always must run code here!
        }
        
        public ArrVal
        {
           get { return _array; }
           set { _array = value; }
        }
    }
    ...
    MyArray<int> myArray = new MyArray<int>(); // your custom code gets executed when you new up the object here
