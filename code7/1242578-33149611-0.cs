    [ExecuteInEditMode]
    public class tester : MonoBehaviour 
    {
        public Transform PairedTransform;
        void Update()
        {
            gameObject.transform.localScale = PairedTransform.localScale;
        }
    }
