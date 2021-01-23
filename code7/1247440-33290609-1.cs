    public class ConcreteIndexable : IIndexable
     {
         public int Index
         {
             get { throw new NotImplementedException(); }
         }
         int IIndexSettable.Index
         {
             set { throw new NotImplementedException(); }
         }
     }
