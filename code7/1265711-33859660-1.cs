    public interface IReadOnlyA
    {
         IImmutableList<string> StringList { get; }
    }
    public class A : IReadOnlyA
    {
         public List<string> StringList { get; set; } = new List<string>();
         IImmutableList<string> IReadOnlyA.StringList => StringList.ToImmutableList();
    }
