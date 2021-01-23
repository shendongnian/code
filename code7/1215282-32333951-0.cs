    void Start()
    {
       Invoke("ShowTextTap", 5f);
    }
    void ShowTextTap()
    {
        text_tap.gameObject.SetActive(true);
        //then remove it
        Invoke("DisableTextTap", 5f);
    }
    void DisableTextTap()
    {
        text_tap.gameObject.SetActive(false);
    }
