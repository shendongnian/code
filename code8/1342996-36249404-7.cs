    public class BigScript:MonoBehaviour
        {
        [Header("Here's a cool event! Drag anything here!")]
        public UnityEvent whoa;
        
        private void YourFunction()
          {
          whoa.Invoke();
          }
