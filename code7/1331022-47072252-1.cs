    public static XXXXX Instance { get; private set; }
    void Awake()
    {
    if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }
