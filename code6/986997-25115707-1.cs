    Posting onjPosting = null;
    List<Posting> objList = new List<Posting>();
    for (int i = 0; i < 1; i++)
    {
        onjPosting = new Posting();
        onjPosting.Key1 = i;
        for (int j = 0; j < 5; j++)
        {
            Choice objChoice = new Choice();
            objChoice.ID = i;
            objChoice.VAL = j;
            onjPosting.GetPostingChoice.Add(objChoice); // GETTING ERROR [ Object reference not set to an instance of an object. ] 
        }
        objList.Add(onjPosting);
    }
