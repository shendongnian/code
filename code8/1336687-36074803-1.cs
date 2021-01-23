    var numScenes = SceneManager.sceneCount;
    List<string> sceneNames = new List<string>(numScenes);
    for (int i=0; i < numScenes; ++i)
    {
       sceneNames.Add(StageManager.GetSceneAt(i).name);
    }
