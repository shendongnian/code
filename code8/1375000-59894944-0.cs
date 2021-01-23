    public class Test : MonoBehaviour
    {
       void OnDrawGizmos()
       {
           Rect rect = new Rect(10, 10, 150, 100);
           Handles.BeginGUI();
           UnityEditor.Handles.DrawSolidRectangleWithOutline(rect, Color.black, Color.white);
           Handles.EndGUI();
       }
    }
