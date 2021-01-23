    public interface ITestClass<T> where T : IListItem
    {
        List<T> list { get; set; }
    }
    
