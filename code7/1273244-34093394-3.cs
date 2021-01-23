    public class ExampleTwoClass : MonoBehaviour {
        public AudioSource audioPrefab;
        void OnCollisionEnter() {
            GameObject clone = Instantiate(audioPrefab, transform.position, transform.rotation) as GameObject;
            AudioSource cloneAudio = clone.GetComponent<AudioSource>();
            cloneAudio.play();
            //destroy clone once audio finishes
            Destroy(clone, cloneAudio.clip.length + 0.1f);
        }    
    }
    
