        public class MyValues<T>
        {
            public T value1 { get; set; }
            public T value2 { get; set; }
        }
        public void TakeTwo<T>(MyValues<T> myvalue)
        {
            baseAPI.getvalues(myvalue.value1, myvalue.value2);
        }
