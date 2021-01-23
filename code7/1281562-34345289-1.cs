    public interface ICut
    {
       DoSomething();
    }
    
    public class RoundCut : ICut
    {
        DoSomething(){}
    }
    
    public class SquareCut : ICut
    {
        DoSomething(){}
    }
----------
    public interface IRoll
    {
        IEnumerable<ICut> Cuts { get; };      
    
        ICut CreateCut();
    }
    
    public class RoundRoll : IRoll
    {        
        public IEnumerable<ICut> Cuts { get; private set; }
        public RoundRoll ()
        {
            this.Cuts = new List<ICut>();
        }
    
        public ICut CreateCut()
        {
            var cut = new RoundCut();
            this.Cuts.Add(cut);
            
            return cut;
        }
    }
    
    public class SquareRoll : IRoll
    {
        public IEnumerable<ICut> Cuts { get; private set; }
        public SquareRoll ()
        {
            this.Cuts = new List<ICut>();
        }
    
        public ICut CreateCut()
        {
            var cut = new SquareCut();
            this.Cuts.Add(cut);
            
            return cut;
        }
    }
