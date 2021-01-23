    void Start<T>(T wantedType) where T : new(), thingy
    {
    
        List<thingy> collectionOfStuff = new List<thingy>();
    
        for(int i = 0; i < 3; i++){
            //here I want to add the type awsomething or one of the other classes
            //that derive from thingy but I don't know which one it is
    
            collectionOfStuff.Add(new T()); //Will create based off the passed type of T
        }
    }
