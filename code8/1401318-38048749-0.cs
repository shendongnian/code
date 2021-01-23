    public class MonoBehaviour : Behaviour
     {
         public extern bool useGUILayout
         {
             get;
             set;
         }
         public extern MonoBehaviour();
         private extern void Internal_CancelInvokeAll();
         private extern bool Internal_IsInvokingAll();
         public extern void Invoke(string methodName, float time);
         public extern void InvokeRepeating(string methodName, float time, float repeatRate);
         public void CancelInvoke();
         public extern void CancelInvoke(string methodName);
         public extern bool IsInvoking(string methodName);
         public bool IsInvoking();
         public Coroutine StartCoroutine(IEnumerator routine);
         public extern Coroutine StartCoroutine_Auto(IEnumerator routine);
         public extern Coroutine StartCoroutine(string methodName, object value);
         public Coroutine StartCoroutine(string methodName);
         public extern void StopCoroutine(string methodName);
         public extern void StopAllCoroutines();
         public static void print(object message);
     }
