    public class NormalizedWordComparer : IEqualityComparer<Word> {
         public bool Equals(Word x, Word y) {
              return x.Normalized == y.Normalized;
         }
         public int GetHashCode(Word obj) {
              return obj.Normalized.GetHashCode();
         }
    }
    
    public class RootWordComparer: IEqualityComparer<Word> {
         public bool Equals(Word x, Word y) {
              return x.Root == y.Root;
         }
         public int GetHashCode(Word obj) {
              return obj.Root.GetHashCode();
         }
    }
    
    public class SubrootWordComparer : IEqualityComparer<Word> {
         public bool Equals(Word x, Word y) {
              return x.Subroot == y.Subroot;
         }
         public int GetHashCode(Word obj) {
              return obj.Subroot.GetHashCode();
         }
    }
