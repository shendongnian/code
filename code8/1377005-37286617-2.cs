    void Start()
    {
        Tool mytools = new Tool();
    
        //Add 1 new Hammer
        mytools.addNewHammer();
    
        //Add 10 Hammers
        mytools.addNewHammer(10);
    
    
        //Get numRemaining
        mytools.getRemainingNum(0);
    
        //Remove a Hammer by index
        mytools.removeHammer(0);
    
        //Remove all Hammers
        mytools.removeAllHammer();
    
        //Get Hammer instance
        Hammer myhammer = mytools.getCurrentHammerInstance(0);
    
        //Get All Hammer instance as array
        Hammer[] allHammers = mytools.getAllHammerInstance();
    
        //Loop through all numRemaining from each hammer
        for (int i = 0; i < allHammers.Length; i++)
        {
            Debug.Log(allHammers[i].getRemainingNum());
        }
    }
