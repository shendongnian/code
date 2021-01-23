    Bystander[] bystanders;
    void Awake()
    {
        bystanderObjects = GameObject.FindGameObjectsWithTag ("NPC");
        bystanders = new Bystander[bystanderObjects.Length];
        for (var i = 0; i < bystanderObjects.Length; ++i)
        {
            bystander[i] = bystanderObjects[i].GetComponent<Bystander>();
        }
    }
