    using System;
    
    namespace BusinessRule
    {
      public enum SalaryCriteria : int
      {
        Per_Month = 1,
    
        Per_Year = 2,
    
        Per_Week = 3
      }
    }
    
    namespace ConsoleApplication16
    {
      internal class Program
      {
        private static void Main()
        {
          string EnumAtt = "BusinessRule.SalaryCriteria";
          Type myType1 = Type.GetType(EnumAtt);
    
          Console.WriteLine(myType1.AssemblyQualifiedName);
          Console.ReadLine();
        }
      }
    }
