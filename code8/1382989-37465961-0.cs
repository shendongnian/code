    public class MyClass 
    {
      // variable 'a' is initialize as a = 5 only once
      private int a = 5;
    
      private void CalculateSum(int b)
      {
        // every time the function is called it uses this (a) value
        int sum  = a + b;
    
        // But if sum = 10... 
        if (sum == 10)
        {
            // then value of 'a' changes to 10
            a = 10; 
        }
      }
  
      // Some other code here 
    }
