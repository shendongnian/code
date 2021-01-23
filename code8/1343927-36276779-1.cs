    void ChangeObject(ref GameObject objParam)
    {
       objParam = new GameObject("Eve");
    }
    void Start(){
        GameObject obj = new GameObject("Adam");
        ChangeObject(ref obj);
        Debug.Log(obj.name); // Yeah it is Eve !!!
    }
