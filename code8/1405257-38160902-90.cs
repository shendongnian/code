    private List<GameObject> obstacles ..
    
    void CreateObstacle()
     {
     if ( obstacles.Length >= 25 )
       {
       CancelInvoke( "CreateObstacle" );
       return
       }
     }
