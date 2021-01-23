    private Vector3 ChoosePosition()
     {
     Vector3 result;
     result = RandomPositionOnYourMap()
     while ( NearestTo(result) < 2f )
       {
       result = RandomPositionOnYourMap()
       }
     return result;
     }
    
    private float NearestTo(Vector3 p)
     {
     // NB there are easier ways to do this. just for learning.
     float n = 1000f;
     foreach (GameObject g in obstacles)
      {
      float d =Vector3.Distance(g.transform.position,p);
      if (d<n) n=d;
      }
     return n
     }
