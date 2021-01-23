    [ExecuteInEditMode]
    public class TransferRegion : MonoBehaviour {
        //...
        [SerializeField]
        private UnityEvent rescaled;
        //...
        void Update() {
            if (scale != gameObject.transform.localScale) {
                scale = gameObject.transform.localScale;
                rescaled.Invoke();
            }
        }
        //...
        public void OnPairRescaled() {
            gameObject.transform.localScale = pair.transform.localScale;
            scale = gameObject.transform.localScale;
        }
    }
