    public class WaterController : MonoBehaviour {
        public GameObject FPobj;
        private FirstPersonController FPC;
        void Start() {
            FPC = FPobj.GetComponent<FirstPersonController>();
        }
    }
