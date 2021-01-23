    using System.Collections.Generic;      // For list
    private List<GameObject> objectList;
    public float randomMin = 2f;
    public float randomMax = 4f;
    void Start(){
      objectList = new List<GameObject>();
      Spawn();
    }
    void Spawn() 
    { 
         objectList.Clear();     ///For multiple spawn purpose dont dublicate items.
         float startPosX = 0f; // I assume your camera look at 0,0,0 point.
         for (int i = 0; i < 10; i++){ 
             Vector3 spawnPos = new Vector3(startPosX,0f,0f);
             GameObject newObject = Instantiate(obj, spawnPos, Quaternion.identity) as GameObject; 
             objectList.Add(newObject);
             float randomX = Random.Range(randomMin,randomMax);
             startPosX+=randomX;
         }
    } 
    void DestroyObject(){
         for(int i=0;i<objectList.Count;i++){
             Destroy(objectList[i]);
         }
    } 
