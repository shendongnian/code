    public class ExampleClass : MonoBehaviour 
    {
        public Texture btnTexture;
        void OnGUI() 
         {
            if (!btnTexture) 
            {
                Debug.LogError("Please assign a texture on the inspector");
                return;
            }
            if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture),GUIStyle.None)
                Debug.Log("Clicked the button with an image");
            
           //Pass Guistyle None so that it behaves like image not a button.
            
        }
    }
