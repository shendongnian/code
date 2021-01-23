    public class Example : MonoBehaviour
    {
        private delegate IEnumerator CoroutineDelegate();
    
        private IEnumerator CoroutineA()
        {
        }
    
        private IEnumerator CoroutineB()
        {
        }
    
        public void Start()
        {
            CoroutineDelegate crt = CoroutineA;
            StartCoroutine(crt);
        }
    }
