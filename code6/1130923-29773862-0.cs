    public class SourceCodeTypeNameAttribute : Attribute
    {
        public string Name { get; set; }
        public SourceCodeTypeNameAttribute(string name)
        {
            this.Name = name;
        }
    }
    [SourceCodeTypeName("A")]
    public abstract class A
    {
        public decimal MyProp { get; set; }
    }
    [SourceCodeTypeName("B")]
    public class B : A
    {
    }
    [SourceCodeTypeName("C<T>")]
    public class C<T> : A
    {
    }
