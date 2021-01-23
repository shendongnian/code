    public interface IName
    {
        string Name { get; }
    }
    public class CFoo : CBar
    {
        
    }
    abstract public class CBar : IName
    {
        public override string ToString()
        {
            //Do work here
            return base.ToString();
        }
        public string Name { get; }
    }
