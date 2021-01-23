    void Awake () 
    {
        text = GetComponent<Text> ();
        bystanderObjects = GameObject.FindGameObjectsWithTag ("NPC");
        foreach (GameObject bystanderObject in bystanderObjects) 
        {
            bystander = bystanderObject.GetComponent<Bystander> ();
        }
    }
