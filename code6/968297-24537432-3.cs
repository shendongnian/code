    public class MovePlayerAction : IAction
    {
        public GameObject playerObject;
    
        private IEnumerator Coroutine()
        {
            yield return StartCoroutine(WaitFor(3)); // Wait 3 secs
    
            float animDuration = 5.0f;
            Vector3 initialPos = Vector3.zero;
            Vector3 finalPos = Vector3.one;
            float t = 0;
            while (t < animDuration)
            {
                playerObject.transform.position = Vector3.Lerp(initialPos, finalPos, t / animDuration); // Lerp between initial and final
                yield return null; // Wait a frame
                t += Time.deltaTime;
            }
        }
    
        public void Execute()
        {
            StartCoroutine(Coroutine());
        }
    
        private IEnumerator WaitFor(float secs)
        {
            float t = 0;
            while (t < secs)
            {
                yield return null; // Wait a single frame
                t += Time.deltaTime;
            }
        }
    }
