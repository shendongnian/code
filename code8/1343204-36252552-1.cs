    public class MbClass : MonoBehaviour
    {
        public Act1_1HomeAwake homeAwake;
        void Start(){
             // Considering you don't pass the MB in ctor anymore.
             this.homeAwake = new Act1_1HomeAwake();
             StartCoroutine(this.homeAwake.OpenCloseEyesAnimation());
        }
    }
