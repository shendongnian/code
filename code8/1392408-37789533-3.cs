    //in my case, heavy calculations are static in another class
    public static class Calculator
    {
      public static bool DoHeavy(bool exampleArg)
      {
        //loong and heavy calculations
      }
  
    }
    public class ExampleClass : MonoBehaviour {
    
      IEnumerator coroutineSomeFunc()
      {
        bool result = false;
        //code to show "thinkng sign"
        UnityTask t = UnityTask.Run( () => {
          //and no freesing now
          result = Calculator.DoHeavy(myArg);
        });
        yeild return t;
        //code to hide "thinkng sign"
        if (result)
        {
          //continue game flow
        }
      }
    
      public void SomeFunc()
      {
        StartCoroutine(coroutineSomeFunc());
      }
    }
