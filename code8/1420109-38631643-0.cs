    internal interface IComplexClass
    {
        IDictionary<string, ComplexElement> Elements { get; }
    }
    public abstract class ComplexClass<T> : ComplexBase, IComplexClass where T : ComplexElement
    {
        internal SortedList<string, T> Elements { get; set; }
        IDictionary<string, ComplexElement> IComplexClass.Elements
        {
            get { return (IDictionary<string, ComplexElement>)Elements; }
        }
    }
