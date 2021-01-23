    public GameObject gOBJ =null;
    void Start()
    {
     Invoke("showGameObject", 2);
    }
    
    void showGameObject()
    {
     gOBJ.SetActive(true);
    }
