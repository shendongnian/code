     public class ExampleClass : MonoBehaviour 
        {
            public GUIStyle style;
            void OnGUI() 
            {
                GUI.skin.label = style;
                GUILayout.Label("This is a label.");
                Debug.Log("" + GUI.skin.button.hover.textColor);
                 
            }
        }
