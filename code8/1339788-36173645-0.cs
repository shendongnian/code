    public List<GameObject> ActiveChunks = new List<GameObject>();
    var tempActiveChunks = ActiveChunks; //temp variable
    
    public static void DeActivate(GameObject Obj)
    {
        //Do lots of other stuff based on the Obj
        ....
        ....
        tempActiveChunks.Remove(Obj);
     }
    
    public static void DeActivateAllChunks()
    {
        for (int c = 0; c < instance.ActiveChunks.Count; c++)
        {
            DeActivate(instance.ActiveChunks[c], false);
        }
        instance.ActiveChunks = tempActiveChunks;
     }
