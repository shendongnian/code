    public class BasicData {}
    public class AdvancedData : BasicData { }
    public class BasiccControl<T> where T : BasicData
    {
        private T data;
        public T Data;
    }
    public class AdvancedControl : BasicControl<AdvancedData>
    {
    }    
