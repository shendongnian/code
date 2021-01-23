    var sceneNames = new List<string>();
    var regex = new Regex(@"([^/]*/)*([\w\d\-]*)\.unity");
    for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
    {
        var path = SceneUtility.GetScenePathByBuildIndex(i);
        var name = regex.Replace(path, "$2");
        sceneNames.Add(name);
    }
