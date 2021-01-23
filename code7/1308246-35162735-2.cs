    GameObject[] gameObjects = null;
    if (gameType == GameType._3D){    
         gameObjects = Mapper.Map<Collider, GameObject>(colliders); }
    
    else if(gameType == GameType._2D) {
        gameObjects = Mapper.Map<Collider2D, GameObject> (colliders); };
