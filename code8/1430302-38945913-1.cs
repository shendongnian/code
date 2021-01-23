    public class Wait : MonoBehaviour {
        private int i = 0;
        public string[] message;
    
        [SerializeField]
        private Text toText;
    
        public IEnumerator Message(float waitTime)
        {
            // toText.text = message[i];
            i++;
            yield return new WaitForSeconds(waitTime = 2f);
        }
    
        void Start()
        {
            StartCoroutine(startMessage());
        }
    
        IEnumerator startMessage()
        {
            yield return StartCoroutine(Message(i));//Wait until this coroutine function retuns
            yield return StartCoroutine(Message(i));//Wait until this coroutine function retuns
            yield return StartCoroutine(Message(i));//Wait until this coroutine function retuns
            yield return StartCoroutine(Message(i));//Wait until this coroutine function retuns
        }
    }
