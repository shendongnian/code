    baseAbstractClass ReturnMeAnObject(int whichObject)
    {
       baseAbstractClass toReturn = null;
    
       if (whichObject == 0)
       {
           toReturn = new Derived();
       }
       else
       if (whichObject == 1)
       {
           toReturn = new DerivedEx();
       }
       return toReturn;
    }
