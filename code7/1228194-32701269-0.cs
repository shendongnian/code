    class gameobject
    {
        public bool isDestroyed {get;set;}
    }
    class bomb : gameobject
    {
    }
    
    main loop update:
    
    for(i = gameobjectcollection.Length; i--; i > -1 )
    {
       if(gameobjectcollection[i].isDestoryed) gameobjectcollection[i] = null;//or whatever to remove by index
    }
