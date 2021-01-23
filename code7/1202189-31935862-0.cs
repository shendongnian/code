    public interface IHaveProperty
    {
        string Property { set; }
    }
    public class SomeClass<TElement> where TElement : IHaveProperty
    {
        TElement _element;
        void SomeFunction() 
        {
             // the generic constraint on TElement says that 
             // TElement must implement IHaveProperty, so you can
             // access Property here.
             _element.Property = string.Empty;
        }
    }
