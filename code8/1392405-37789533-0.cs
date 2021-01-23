    public class ExampleClass : MonoBehaviour {
      public bool MyHeavyCalculator(bool exampleArg)
      {
        //loong and heavy calculations
      }
    
      public void SomeFunc()
      {
        //and here we get freezing
        if (MyHeavyCalculator(boolArg))
        {
          //unfreeze here
        }
      }
    }
