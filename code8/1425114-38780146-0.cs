    var listItem = new List<string> { "alex", "aa" };
    var typeOfGeneric = listItem.GetType().GetGenericArguments().First<Type>();
    var mi = typeof(Extensions).GetMethod("List");
    var stringGeneric = mi.MakeGenericMethod(typeOfGeneric);
    stringGeneric.Invoke(null, new object[] { listItem });
