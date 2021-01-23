    public interface IData
    {
        void Accept(IDataVisitor visitor);
    }
    public interface IDataVisitor
    {
        void Visit(DataA data);
        void Visit(DataB data);
        void Visit(DataC data);
    }
    public class DataA : IData { public void Accept(IDataVisitor visitor) {visitor.Visit(this);}}
    public class DataB : IData { public void Accept(IDataVisitor visitor) {visitor.Visit(this);}}
    public class DataC :  IData { public void Accept(IDataVisitor visitor) {visitor.Visit(this);}}
    public class ConsoleVisitor : IDataVisitor
    {
        public void Visit(DataA data)
        {
            Console.WriteLine("A" + data);
        }
        public void Visit(DataB data)
        {
            Console.WriteLine("B" + data);
        }
        public void Visit(DataC data)
        {
            Console.WriteLine("C" + (data);
        }
    }
