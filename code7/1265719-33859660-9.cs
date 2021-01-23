    public class A : IReadOnlyA
    {
         private IImmutableList<string> _immutableStringList;
         public List<string> StringList { get; set; } = new List<string>();
         IImmutableList<string> IReadOnlyA.StringList
         {
             get
             {
                 // An intersection will verify that the entire immutable list
                 // contains the exact same elements and count of mutable list
                 if(_immutableStringList.Intersect(StringList).Count == StringList.Count)
                    return _immutableStringList;
                 else
                 {
                      // the intersection demonstrated that mutable and
                      // immutable list have different counts, thus, a new
                      // immutable list must be created again
                     _immutableStringList = StringList.ToImmutableList();
                     
                     return _immutableStringList;
                 }
             }
         }
    }
