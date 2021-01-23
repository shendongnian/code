    public interface IFeature
    {
        void Accept(Visitior visitor);
    }
    public class FeatureA : IFeature
    {
        public void Accept(Visitior visitor)
        {
            visitor.Visit(this);
        }
    }
    public class FeatureB : IFeature
    {
        public void Accept(Visitior visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Visitior
    {
        public void Visit<TFeature>(TFeature feature) where TFeature : IFeature
        {
            Console.WriteLine(typeof(TFeature) == feature.GetType());//True
        }
    }
    static void Main(string[] args)
    {
        List<IFeature> features = new List<IFeature>
        {
             new FeatureA(),
             new FeatureB()
        };
        Visitior visitor = new Visitior();
        foreach (var item in features)
        {
            item.Accept(visitor);
        }
    }
