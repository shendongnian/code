    public abstract class JunkThing
    {
         public TJunkThing CopyTo<TJunkThing>(TJunkThing destination) where TJunkThing : JunkThing
         {
              destination.Value1 = Value1;
              destination.Value2 = Value2;
         }
  
    }
