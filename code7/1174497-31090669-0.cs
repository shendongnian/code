    MyBaseClass[] MyObjects = new MyRealClass[3];
    for(Int32 i = 0; i < MyObjects.Length; i++)
    [
        MyObjects[i] = new MyRealClass();
    }
    // ... snip
    foreach(MyBaseClass c in MyObjects)
    {
        c.New();
    }
