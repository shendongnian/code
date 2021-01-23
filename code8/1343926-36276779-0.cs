    void ChangeObject(GameObject objParam)
    {
       objParam = new GameObject("Eve");
    }
    void Start(){
        GameObject obj = new GameObject("Adam");
        ChangeObject(obj);
        Debug.Log(obj.name); // Adam...hold on should be Eve (??!!)
    }
