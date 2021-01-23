    public class AlwaysMoveOnYTowards:MonoBehaviour
     {
     [System.NonSerialized] public float targetY;
     void Update()
      {
      float nextY = .. lerp, or whatever, towards targetY;
      transform.ForceY(nexyT);
      }
     }
