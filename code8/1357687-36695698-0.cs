      public class Class1 : 
         IInfoCardFactory, 
         IInfoCard  // <- notice IInfoCard implementation
      {
         public IInfoCard CreateNewInfoCard(string category)
         {
            Class1 x;
            x = new Class1();
            return x;// i keep at getting error CS0266 at this return statement.
         }
         ...
         //TODO: put here IInfoCard methods and properties implementations
      }
