    public abstract class MyBase 
    {
        public void ProcessData()
        {
            bool processData = true;
        }
        public MyBase()
        {
            bool myBase = true;
        }
        public MyBase(int pass)
        {
            bool myBase = true;
        }
    }
    public class Example : MyBase
    {
        public void GetData() {}
        public Example()
            : base(1)
        {
            bool example = true;
            GetData();
            ProcessData();
        }
    } 
