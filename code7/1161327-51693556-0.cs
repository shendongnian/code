            using UnityEngine.SceneManagement;
    ///***///
            public void LoadGameLevel(int SceneToChangeTo)
            { SceneManager.LoadScene(SceneToChangeTo);
            }
        //or
            public void LoadGameLevel(string SceneName)
            { SceneManager.LoadScene(SceneName);
            }
