    void Awake()
    {
        sprite = GetComponent<Image>();
        Debug.Log("Awake has been called, sprite is " + sprite);
        Debug.Log("neutral is " + neutral);
        Debug.Log("highlight is " + highlight);
    }
