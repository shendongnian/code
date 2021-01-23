    BaseModel finalModel = null;
    if (conditionA)
    {
        finalModel = new ExtendedModelA()
                         {
                             exclusivePropertyA = "some value";
                         };
    }
    else
    {
        finalModel = new ExtendedModelB()
                         {
                             exclusivePropertyB = "some other value";
                         };
    }
    finalModel.sharedProperty1 = "asdf";
    // assign the rest of the values
