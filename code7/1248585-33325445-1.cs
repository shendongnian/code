    object[] parameters = new object[4];
    for (var i = 0; i < parameters.Length; i++) {
	     parameters[i] = i < myList.Count ? myList[i] : Type.Missing;
    }
    MethodInfo mi = typeof(SomeClass).GetMethod(nameof(SomeClass.SomeFunction));
    string result = (string)mi.Invoke(null, parameters);
