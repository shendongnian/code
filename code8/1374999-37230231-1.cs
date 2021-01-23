    public class Test : MonoBehaviour
    {
       void OnDrawGizmos()
       {
           Rect rect = ScreenRect(10, 10, 150, 100);
           UnityEditor.Handles.DrawSolidRectangleWithOutline(rect, Color.black, Color.white);
       }
    ...
