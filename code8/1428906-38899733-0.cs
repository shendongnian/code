    Vector3[] defaultPos;
    Vector3[] defaultScale;
    Quaternion[] defaultRot;
    
    Transform[] models;
    
    //Attach Button from the Editor
    public Button resetButton;
    
    void Start()
    {
        //Call to back up the Transform before moving, scaling or rotating the GameObject
        backUpTransform();
    }
    
    void backUpTransform()
    {
        //Find GameObjects with Model tag
        GameObject[] tempModels = GameObject.FindGameObjectsWithTag("Model");
    
        //Create pos, scale and rot, Transform array size based on sixe of Objects found
        defaultPos = new Vector3[tempModels.Length];
        defaultScale = new Vector3[tempModels.Length];
        defaultRot = new Quaternion[tempModels.Length];
    
        models = new Transform[tempModels.Length];
    
        //Get original the pos, scale and rot of each Object on the transform
        for (int i = 0; i < tempModels.Length; i++)
        {
            models[i] = tempModels[i].GetComponent<Transform>();
    
            defaultPos[i] = models[i].position;
            defaultScale[i] = models[i].localScale;
            defaultRot[i] = models[i].rotation;
        }
    }
    
    //Called when Button is clicked
    void resetTransform()
    {
        //Restore the all the original pos, scale and rot  of each GameOBject
        for (int i = 0; i < models.Length; i++)
        {
            models[i].position = defaultPos[i];
            models[i].localScale = defaultScale[i];
            models[i].rotation = defaultRot[i];
        }
    }
    
    
    void OnEnable()
    {
        //Register Button Events
        resetButton.onClick.AddListener(() => resetTransform());
    
    }
    
    
    void OnDisable()
    {
        //Un-Register Button Events
        resetButton.onClick.RemoveAllListeners();
    }
