    public List<GameObject> myObjectList = new List<GameObject>();
    public List<Transform> myTransformList =  new List<Transform>();
    myObjectList = GameObject.FindGameObjectsWithTag("YourCustomTagHere");
    foreach(Gameobject g in myObjectList)
    {
     myTransformList.Add(g.transform);
    }
