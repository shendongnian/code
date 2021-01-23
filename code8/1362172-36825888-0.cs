    public interface IExample
    {
        string Name
        {
            get;
        }
    }
    internal interface IExampleInternal
    {
        string Name
        {
            set; get;
        }
    }
    internal class Example : IExample, IExampleInternal
    {
        public string Name { get; set; } = string.Empty;
    }
