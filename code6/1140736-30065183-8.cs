    void Start()
    {
        StartCoroutine(inputWaiter());
    }
    
    IEnumerator inputWaiter()
    {
        Debug.Log("Waiting for the Exit button to be pressed");
        yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.Escape));
        Debug.Log("Exit button has been pressed. Leaving Application");
    
        //Exit program
        Quit();
    }
    
    void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
