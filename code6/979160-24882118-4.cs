    public abstract class A : IWithCategories, IWithComments
    {
        abstract public int Id { get; }
        abstract public IList<string> Categories { get; }
        abstract public IList<string> Comments { get; }
    }
