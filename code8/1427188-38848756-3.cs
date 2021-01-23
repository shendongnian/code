    public interface IName
    {
        string Name { get; }
    }
    public class CBaz : CBar
    {
        
    }
    public class CFoo : CBar, IName 
    {
        public CFoo(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
    abstract public class CBar 
    {
        public override string ToString()
        {
            if (this is IName)
            {
                var temp = (IName) (this);
                return temp.Name;
            }
            else
            {
                return base.ToString();
            }
        }
    }
