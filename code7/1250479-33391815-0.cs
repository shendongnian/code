    namespace A
    {
         public class AClass
         {
             public int Field = B.BClass.Constant;
         }
    }
    namespace B
    {
         public class BClass
         {
             public const int Constant = 42;
         }
    }
