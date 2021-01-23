    public class Penduluum : MonoBehaviour {
     public float angle = 45.0f;
     public float speed = 1.5f;
     
     Quaternion Start, End;
     
     void Start () {
         Start = Quaternion.AngleAxis ( angle, Vector3.forward);
         End   = Quaternion.AngleAxis (-angle, Vector3.forward);
     }
     
     void Update () {
       transform.rotation = Quaternion.Lerp (Start, End, (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f);
     }
 }
