    public class Examplebutton : MonoBehaviour {
    
        void OnGUI() {
    
            if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
            Debug.Log("Clicked");
    
        }
    }
