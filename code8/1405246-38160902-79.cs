    public void ReplacementIsNext(Vector3 p)
     {
     if (replacors.Length == 0)
      {
      CancelInvoke("CreateObstacle");
      InvokeRepeating( "CreateObstacle", 1f, 2f );
      }
     replacors.Add(p);
     }
