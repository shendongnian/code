    foreach (object thingDoer in listOfThings)
    {
       // get Do via reflection and create specific version based on 
       // thingDoer.GetType(), than invoke 
       // consider caching "methodForType" in Dictionary by type
       MethodInfo method = this.GetType().GetMethod("Do");
       MethodInfo methodForType = method.MakeGenericMethod(thingDoer.GetType());
       methodForType.Invoke(thingDoer, null);
       
    }
    void Do<T>( MyInterface<T> thingDoer)
    {
        T something = thingDoer.GetSomething();
        thingDoer.DoSomething(something);
        thingDoer.DoSomething(something);
    }
