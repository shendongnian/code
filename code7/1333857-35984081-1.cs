    public class CubeScript : MonoBehaviour
    {
        public GameObject ui;        
        void OnMouseDown()
        {
            ui.setActive(!ui.activeSelf);    // or just true if no toggle
            // or 
            ui.enabled = !ui.enabled;        // for older versions
        }
    }
