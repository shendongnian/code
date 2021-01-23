    Type bound = new List<string>().GetType().GetInterface("IList`1");
    bound.GenericTypeArguments.Single().Dump(); //string
    Type bound = typeof(List<>).GetInterface("IList`1");
    bound.GenericTypeArguments.Single().Dump(); //"T"
    (bound.GenericTypeArguments.Single() == typeof(List<>).GetGenericArguments().Single()).Dump(); //true
