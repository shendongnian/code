    ...
        private void Awake()
        {
    
            if (LoadingSceneIntegration.otherScene > 0)
            {
                Debug.Log("Returning again to the scene: " + LoadingSceneIntegration.otherScene);
                SceneManager.LoadScene(LoadingSceneIntegration.otherScene);
            }
        }
    ...
