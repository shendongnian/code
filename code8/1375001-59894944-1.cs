    public class Test : MonoBehaviour
    {
       void OnDrawGizmos()
       {
           Rect rect = new Rect(10, 10, 150, 100);
           UnityEditor.Handles.BeginGUI();
           UnityEditor.Handles.DrawSolidRectangleWithOutline(rect, Color.black, Color.white);
           UnityEditor.Handles.EndGUI();
       }
    }
