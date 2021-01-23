    public float spawnDistanceFactor = 2f; //Value is your choice. You can change it.
    void Spawn() 
    { 
         float startPosX = 0f; // I assume your camera look at 0,0,0 point.
         for (int i = 0; i < 10; i++){ 
             Vector3 spawnPos = new Vector3(startPosX,0f,0f);
             Instantiate(obj, spawnPos, Quaternion.identity); 
             startPosX+=spawnDistanceFactor;
         }
     
    } 
