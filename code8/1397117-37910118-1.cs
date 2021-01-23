    if (_newGameButton.Contains (Event.current.mousePosition))
      {
      Invoke("YourSceneName");
      }
    
    private void ChangeScenes()
     {
     UnityEngine.SceneManagement.SceneManager.LoadScene("ScreenMain");
     }
