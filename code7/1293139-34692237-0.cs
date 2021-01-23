    bool fading;
    float fadeValue = 0;
    const float INCREMENT = 0.01f;
    ScreenOverlay so;
    void OnTriggerEnter(Collider other)
    {
        fading = true;
    }
    void Start()
    {
        so = gameObject.GetComponent<ScreenOverlay>();
        fading = true;
    }
    void Update()
    {
        if (fading)
        {
            fadeValue += INCREMENT;
            so.intensity = fadeValue * 2;
            if (fadeValue >= 1)
            {
                fading = false;
                // change player position
            }
        }
        else if (fadeValue > 0)
        {
            fadeValue = Mathf.Max(0, fadeValue - INCREMENT);
            so.intensity = fadeValue * 2;
        }
    }
