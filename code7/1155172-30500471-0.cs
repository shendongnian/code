    /// <summary>
    /// some base class
    /// </summary>
    public class BaseClass
    {
        public string Name { get; set; }
    
        public BaseClass()
        {
            this.Name = "I'm basic class";
        }
    }
    
    /// <summary>
    /// inherited class 1
    /// </summary>
    public class CoolClass : BaseClass
    {
        public string Name { get; set; }
    
        public CoolClass()
        {
            this.Name = "I'm cool class :)";
        }
    }
    
    /// <summary>
    /// inherited class 2
    /// </summary>
    public class SadClass : BaseClass
    {
        public string Name { get; set; }
    
        public SadClass()
        {
            this.Name = "I'm sad class :(";
        }
    }
    
    /// <summary>
    /// container
    /// </summary>
    /// <typeparam name="T"> element type </typeparam>
    public class UniversalContainer<T> where T : BaseClass
    {
        public List<T> Container { get; private set; }
    
        public UniversalContainer()
        {
            this.Container = new List<T>();
        }
    }
