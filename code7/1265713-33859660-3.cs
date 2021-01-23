    public class A
    {
         private List<string> StringListInternal { get; set; } = new List<string>();
         public IImmutableList<string> StringList => StringListInternal.ToImmutableList();
    }
