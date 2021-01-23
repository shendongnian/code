    public ActionResult Test(string className)
    {
        MethodInfo method = typeof(ConfigController).GetMethod("Generic");
        MethodInfo generic = method.MakeGenericMethod(Type.GetType(className));
        ActionResult ret = (ActionResult)generic.Invoke(this, null);
        return ret; 
    }
