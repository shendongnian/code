    public interface IHasParents
    {
        IReadOnlyList<Person> Parents { get; }
    }
    public interface IPerson : IHasParents
    {
        long Id { get; set; }
        string Name { get; set; }
    }
