    private index ChoosePosition()
     {
     int result;
     result = Random.Range(0, spawnPoints.Count);
     while (IndexIsAlreadyUsed(result)
       result = Random.Range(0, spawnPoints.Count);
     return result;
     }
    private IndexIsAlreadyUsed(int i)
      {
      foreach(YourObstacle y in obstacles)
        { if y.mySpawnPointIndexWas == i ) return true; }
      return false;
      }
