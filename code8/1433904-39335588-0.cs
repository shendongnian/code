    using UnityEngine;
    public class ScriptA : MonoBehaviour
    {
      public ScriptB anyName;
    
    
      void Update()
      {
        anyName.DoSomething();
      }
    }
----------
    using UnityEngine;
    public class ScriptB : MonoBehaviour
    {
      public void DoSomething()
      {
         Debug.Log("Hi there");
      }
    }
