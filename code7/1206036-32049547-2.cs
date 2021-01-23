    public void DoSomething(object arrayData, Type arrayType)
    {
        MethodInfo mi = this.GetType().GetMethod("DoSomethingGeneric").MakeGenericMethod(arrayType);
        mi.Invoke(this, new object[] { arrayData });
    }
