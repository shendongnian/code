    GameObject[] gameObjects = null;
    if (gameType == GameType._3D){    
         gameObjects = Mapper.Map<List<Collider>, List<GameObject>>(colliders); }
    
    else if(gameType == GameType._2D) {
        gameObjects = Mapper.Map<List<Collider2D>, List<GameObject>> (colliders); };
